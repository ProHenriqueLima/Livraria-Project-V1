<template>
  <v-app class="grey darken-4">
    <nav-bar />
<v-card
      class=" my-12 purple darken-3 text-center mx-auto"
     width="1050"
      height="50"
    >
      <h1 class="white--text mt-1 font-weight-black">
        Ultimo Livro Cadastrado
      </h1>
    </v-card>
    <v-row class="mx-auto mb-5">
      <v-card
        class=" mt-5 purple darken-3
 text-center mr-4"
        width="350"
        height="150"
      >
        <div>
          <v-card-title class=" white--text text-center"
            ><h3>Nome</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoLivro.nomeLivro }}</b>
          </h1>
        </div>
      </v-card>

      <v-card
        class=" my-5 purple darken-3
 text-center"
        width="350"
        height="150"
      >
        <div>
          <v-card-title class=" white--text text-center mx-4"
            ><h3>Autor</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoLivro.autorLivro }}</b>
          </h1>
        </div>
      </v-card>
    </v-row>

    <v-card class=" mt-12  purple darken-3
 text-center mx-auto" width="1301" height="50">
      <h1 class="white--text mt-1 font-weight-black">Tabela de Livros</h1>
    </v-card>
    <v-card class="mx-6 mb-8 ">
      <v-card-title>
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Search"
          single-line
          hide-details
        ></v-text-field>
      </v-card-title>
      <v-data-table :headers="headers" :items="Livros" :search="search">
        <template v-slot:[`item.actions`]="{ item }">
          <v-icon small class="mr-2 green--text" @click="editar(item)">
            mdi-pencil
          </v-icon>
          <v-icon small class="red--text" @click="excluir(item.id)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
    </v-card>
    <div class="my-2">
      <v-btn
        color="purple darken-3"
        dark
        fab
        fixed
        bottom
        right
        @click="ModalAdicionar"
      >
        <v-icon dark>
          mdi-plus
        </v-icon>
      </v-btn>
    </div>
    <v-dialog v-model="adicionar" width="unset" height="unset">
      <v-card width="590" height="550" class="text-center rounded-card">
        <v-toolbar class="grey darken-3">
          <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
          <span class="white--text">Livro</span>
          <v-spacer></v-spacer>
          <v-btn size="40" class="grey darken-3" @click="fecharmodel">
            <v-icon size="30" color="red">mdi-close</v-icon>
          </v-btn>
        </v-toolbar>

        <form @submit.prevent="salvar" class="py-4">
          <v-text-field
            label="Nome do Livro"
            v-model="Livro.nomeLivro"
            class="py-4 mx-2"
            :rules="nomeRules"
            :counter="30"
          ></v-text-field>

          <div>
            <v-menu
              ref="menu"
              v-model="menu"
              :close-on-content-click="false"
              transition="scale-transition"
              offset-y
              min-width="auto"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="date"
                  label="Lançamento"
                  prepend-icon="mdi-calendar"
                  readonly
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="date"
                :max="
                  new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
                    .toISOString()
                    .substr(0, 10)
                "
                @change="save"
              ></v-date-picker>
            </v-menu>
          </div>

          <v-text-field
            label="Autor"
            v-model="Livro.autorLivro"
            class="py-2 mx-2"
            :rules="autorRules"
          ></v-text-field>

          <v-text-field
            label="Quantidade"
            v-model="Livro.quantidade"
            class="py-2 mx-2"
            :rules="quantidadeRules"
          ></v-text-field>

          <v-select
            v-model="Livro.editoraID"
            :items="Editoras"
            item-text="nameEditora"
            item-value="id"
            filled
            label="Editora"
          ></v-select>

          <button type="submit" class="green darken-3 rounded-card ml-2 ">
            <v-icon size="30" color="white" class="pa-2 ml-2"
              >mdi-book-plus-outline</v-icon
            ><span class="mr-3 text-center green darken-3 white--text">
              Salvar</span
            >
          </button>
        </form>
      </v-card>
    </v-dialog>

    <v-dialog v-model="tabeladata" width="unset" height="unset">
      <v-card width="280" height="400">
        <v-date-picker
          v-model="Livro.lancamentoLivro"
          color="grey darken-3"
        ></v-date-picker>
      </v-card>
    </v-dialog>

    <v-dialog v-model="tabelaedit" width="unset" height="unset">
      <v-card
        width="200"
        height="500"
        v-model="tabelaedit"
        class="text-center rounded-card"
      >
        <v-simple-table class="py-4 mx-4">
          <template v-slot:default>
            <thead>
              <tr class="blue-grey darken-4">
                <th class="text-center white--text">
                  Id
                </th>
                <th class="text-center white--text">
                  Nome da Editora
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="Editora of Editoras"
                :key="Editora.Id"
                :items-per-page="5"
              >
                <td class="text-center">{{ Editora.id }}</td>
                <td class="text-center">{{ Editora.nameEditora }}</td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-card>
    </v-dialog>
    <v-snackbar v-model="snackbar1">
      Livro Deletado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar1 = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar2">
      Livro Adicionado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar2 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar3">
      Livro Atualizado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar3 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
  </v-app>
</template>
<script>
import NavBar from "../components/NavBar.vue";
import Livro from "../services/Livros";
import Editora from "../services/Editoras";
import Swal from "sweetalert2/dist/sweetalert2.js";
var moment = require("moment");
export default {
  name: "Livro",
  components: {
    NavBar,
  },
  data() {
    return {
      Livro: {
        nomeLivro: "",
        lancamentoLivro: "",
        autorLivro: "",
        quantidade: "",
        editoraID: "",
      },
      search: "",
      headers: [
        {
          text: "Id",
          align: "start",
          filterable: false,
          value: "id",
        },
        { text: "Nome do Livro", value: "nomeLivro" },
        { text: "Lançamento", value: "lancamentoLivro" },
        { text: "Autor", value: "autorLivro" },
        { text: "Quantidade", value: "quantidade" },
        { text: "Nome da Editora", value: "editora.nameEditora" },
        { text: "Actions", value: "actions" },
      ],
      activePicker: null,
      date: null,
      menu: false,
      numeroaluguel:"",
      ultimoLivro:[],
      Livros: [],
      Editoras: [],
      adicionar: false,
      alertcadastro: false,
      tabelaedit: false,
      tabeladata: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      nomeRules: [
        (v) => !!v || "O Nome do Livro é obrigatório",
        (v) =>
          v.length >= 3 ||
          "O Nome do Livro não pode ter menos que 3 characters",
        (v) =>
          v.length <= 30 ||
          "O Nome do Livro não pode ter mais que 30 characters",
      ],
      autorRules: [
        (v) => !!v || "O Nome do autor é obrigatório",
        (v) =>
          v.length >= 3 ||
          "O Nome do autor não pode ter menos que 3 characters",
        (v) =>
          v.length <= 30 ||
          "O Nome do autor não pode ter mais que 30 characters",
      ],
      lancamentoRules: [
        (v) => !!v || "O Lançamento é obrigatório",
        (v) =>
          v.length >= 3 || "O Lançamento não pode ter menos que 3 characters",
        (v) =>
          v.length <= 30 || "O Lançamento não pode ter mais que 30 characters",
      ],
      editoraRules: [
        (v) => !!v || "O Editora ID é obrigatório e tem que ser válido !",
        (v) => !isNaN(v) || " O Editora ID pode conter apenas números !",
      ],
      quantidadeRules: [
        (v) => !!v || "A quantidade é obrigatória e tem que ser válida !",
        (v) => !isNaN(v) || " A quantidade pode conter apenas números !",
      ],
    };
  },
  mounted() {
  this.listar(), this.listarEditora();
  },
  methods: {
    modalCalendario() {
      this.tabeladata = true;
    },
    listar() {
      Livro.listar().then((resposta) => {
        this.Livros = resposta.data;
         this.ultimoLivro=this.Livros[this.Livros.length - 1];
      });
    },
  
    listarEditora() {
      Editora.listar().then((resposta) => {
        this.Editoras = resposta.data;
      });
    },
    fecharmodel() {
      this.adicionar = false;
    },
    ModalEditoras() {
      this.tabelaedit = true;
    },
    ModalAdicionar() {
      this.adicionar = true;
    },
    salvar() {
      var save ={
        nomeLivro : this.Livro.nomeLivro,
        lancamentoLivro : moment(this.date).format("YYYY/MM/DD"),
        autorLivro : this.Livro.autorLivro,
        quantidade : this.Livro.quantidade,
        editoraID : this.Livro.editoraID,
      }
      
      if (this.Livro.id == null) {
        Livro.salvar(save).then((resposta) => {
          (this.Livro = resposta),
            this.listar(),
            (this.adicionar = false),
            Swal.fire({
              title: " Sucesso",
              text: "Livro , Adicionado com Sucesso !",
              icon: "success",
              confirmButtonText: "Ok",
            });
        });
      } else {
        Livro.atualizar(this.Livro).then((resposta) => {
          (this.Livro = resposta), this.listar(), (this.adicionar = false);
          Swal.fire({
              title: "Sucesso ",
              text: "Livro atualizado com sucesso",
              icon: "success",
              confirmButtonText: "Ok",
            });
        });
      }
    },
    excluir(id) {
      Swal.fire({
        title: "Você quer mesmo deletar ?",
        text: "Você não irá poder reverter isso !",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sim, Delete!",
      }).then((result) => {
        if (result.isConfirmed) {
          Livro.verificar(id).then((resposta) => {
            this.Livros = resposta.data;
            this.numeroaluguel = this.Livros.length
          if(this.Livros == 0){
            Livro.deletar(id).then((resposta) => {
            (this.Livros = resposta)
          });
          Swal.fire(
            "Deletado!",
            "o Livro foi deletado com sucesso.",
            "success"
          );
           this.listar();
            }
          else{
            Swal.fire(
            "Não Deletado!",
            "O Livro Possui "+this.numeroaluguel+" Alugueis.",
            "error"
          );
          this.listar();
          }
          });
        }
      });
    },
    editar(Livro) {
      (this.Livro = Livro), (this.adicionar = true);
    },
  },
};
</script>
<style>
.rounded-card {
  border-radius: 50px;
}
</style>
