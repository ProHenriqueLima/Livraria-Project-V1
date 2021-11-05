<template>
  <v-app class="grey darken-4">
    <nav-bar />
    <v-card
      class=" my-12 purple darken-3 text-center mx-auto"
      width="1050"
      height="50"
    >
      <h1 class="white--text mt-1 font-weight-black">
        Ultima Editora Cadastrada
      </h1>
    </v-card>
    <v-row class="mx-auto mb-5">
      <v-card
        class=" mt-5 purple darken-3 text-center mr-4"
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
            <b>{{ ultimaEditora.nameEditora }}</b>
          </h1>
        </div>
      </v-card>

      <v-card
        class=" my-5 purple darken-3 text-center"
        width="350"
        height="150"
      >
        <div>
          <v-card-title class=" white--text text-center mx-4"
            ><h3>Cidade</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimaEditora.cidadeEditora }}</b>
          </h1>
        </div>
      </v-card>
    </v-row>

    <v-card
      class=" mt-12 purple darken-3 text-center mx-auto"
      width="1301"
      height="50"
    >
      <h1 class="white--text mt-1 font-weight-black">Tabela de Editoras</h1>
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
      <v-data-table :headers="headers" :items="Editoras" :search="search">
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
      <v-card width="450" height="350" class="text-center">
        <v-toolbar class="grey darken-3">
          <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
          <span class="white--text">Editora</span>
          <v-spacer></v-spacer>
          <v-btn size="40" class="grey darken-3" @click="fecharmodel">
            <v-icon size="30" color="red">mdi-close</v-icon>
          </v-btn>
        </v-toolbar>
        <v-form
          @submit.prevent="salvar"
          ref="form"
          lazy-validation
          class="py-4"
        >
          <v-text-field
            label="Nome da Editora"
            v-model="Editora.nameEditora"
            class="py-4 mx-2"
            :rules="nameRules"
            :counter="30"
          ></v-text-field>
          <v-text-field
            label="Cidade"
            v-model="Editora.cidadeEditora"
            class="py-4 mx-2"
            :rules="cidadeRules"
            :counter="30"
          ></v-text-field>
          <button @click="validate()" class="green darken-3 rounded-card">
            <v-icon size="30" color="white" class="pa-2 "
              >mdi-book-plus-outline</v-icon
            >
          </button>
        </v-form>
      </v-card>
    </v-dialog>

    <v-snackbar v-model="snackbar1">
      Editora Deletado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar1 = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar2">
      Editora Adicionado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar2 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar3">
      Editora Atualizado Com Sucesso !

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
import Editora from "../services/Editoras";
import Swal from "sweetalert2/dist/sweetalert2.js";

export default {
  name: "Editora",
  components: {
    NavBar,
  },
  data() {
    return {
      Editora: {
        nameEditora: "",
        cidadeEditora: "",
      },
      headers: [
        {
          text: "Id",
          align: "start",
          filterable: false,
          value: "id",
        },
        { text: "Nome da Editora", value: "nameEditora" },
        { text: "Cidade da Editora", value: "cidadeEditora" },
        { text: "Actions", value: "actions" },
      ],
      search: "",
      ultimaEditora: [],
      Editoras: [],
      adicionar: false,
      alertcadastro: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,

      nameRules: [
        (v) => !!v || "O Nome da Editora é obrigatório",
        (v) =>
          v.length >= 3 ||
          "O Nome da Editora não pode ter menos que 3 characters",
        (v) =>
          v.length <= 30 ||
          "O Nome da Editora não pode ter mais que 30 characters",
      ],
      cidadeRules: [
        (v) => !!v || "A Cidade é obrigatória",
        (v) => v.length >= 3 || "A Cidade não pode ter menos que 3 characters",
        (v) => v.length <= 30 || "A Cidade não pode ter mais que 30 characters",
      ],
    };
  },
  mounted() {
    this.listar();
  },
  methods: {
    listar() {
      Editora.listar().then((resposta) => {
        this.Editoras = resposta.data;
        this.ultimaEditora = this.Editoras[this.Editoras.length - 1];
      });
    },
   
    fecharmodel() {
      this.adicionar = false;
    },
    ModalAdicionar() {
      this.adicionar = true;
    },
    validate() {
      this.$refs.form.validate();
    },
    salvar() {
      if (this.Editora.id == null) {
        Editora.salvar(this.Editora).then((resposta) => {
          (this.Editora = resposta), this.listar(), (this.adicionar = false);
          Swal.fire({
              title: " Sucesso",
              text: "Editora , Adicionada com Sucesso !",
              icon: "success",
              confirmButtonText: "Ok",
            });
        });
      } else {
        Editora.atualizar(this.Editora).then((resposta) => {
          (this.Editora = resposta), this.listar(), (this.adicionar = false);
           Swal.fire({
              title: "Sucesso ",
              text: "Editora atualizada com sucesso",
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
          Editora.listar2(id).then((resposta) => {
            this.Editoras = resposta.data;
            this.numeroaluguel = this.Editoras.length
          if(this.Editoras == 0){
            Editora.deletar(id).then((resposta) => {
            (this.Editora = resposta), this.listar();
          });
          Swal.fire(
            "Deletado!",
            "A Editora foi deletado com sucesso.",
            "success"
          );
            }
          else{
            Swal.fire(
            "Não Deletado!",
            "A Editora Possui "+this.numeroaluguel+" livros.",
            "error"
          );
          this.listar();
          }
          });
        }
      });
    },
    editar(Editora) {
      (this.Editora = Editora), (this.adicionar = true);
    },
  },
};
</script>
<style>
.rounded-card {
  border-radius: 50px;
}
</style>
