<template>
  <v-app class="grey darken-4">
    <nav-bar />
    <v-card
      class=" my-12 purple darken-3 text-center mx-auto"
      width="1050"
      height="50"
    >
      <h1 class="white--text mt-1 font-weight-black">
        Ultimo Aluguel Feito
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
            ><h3>Cliente</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoAluguel.cliente.nomeCliente }}</b>
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
            ><h3>Livro</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoAluguel.livro.nomeLivro }}</b>
          </h1>
        </div>
      </v-card>

      <v-card
        class=" my-5 purple darken-3 text-center ml-4"
        width="350"
        height="150"
      >
        <div>
          <v-card-title class=" white--text text-center mx-4"
            ><h3>Data do Aluguel</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoAluguel.data_Aluguel }}</b>
          </h1>
        </div>
      </v-card>
    </v-row>

    <v-card class=" mt-12 purple darken-3 text-center mx-auto" width="1301" height="50">
      <h1 class="white--text mt-1 font-weight-black">Tabela de Clientes</h1>
    </v-card>
    <v-card class="mx-6 mb-8">
      <v-card-title>
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Search"
          single-line
          hide-details
        ></v-text-field>
      </v-card-title>
      <v-data-table :headers="headers" :items="Alugueis" :search="search">
        <template v-slot:[`item.status`]="{ item }">
          <div v-if="item.entrega != '' && item.entrega < item.previsao">
            No Prazo !
          </div>
          <div v-if="item.entrega > item.previsao">
            Atraso !
          </div>
          <div v-if="item.entrega == ''">
            Não devolvido
          </div>
        </template>
        <template v-slot:[`item.actions`]="{ item }">
          <div v-if="item.entrega == ''">
            <v-btn
              class="yellow rounded-card "
              title="Devolver"
              @click="editar(item)"
              ><v-icon size="20" class="">mdi-book-arrow-up</v-icon></v-btn
            >
          </div>
          <div v-else>
            <v-btn title="Aluguel Devolvido" class="purple rounded-card" 
              ><v-icon size="20">mdi-book</v-icon
            ></v-btn>
          </div>
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
      <v-card width="490" height="400" class="text-center rounded-card">
        <v-toolbar class="grey darken-3">
          <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
          <span class="white--text">Aluguel</span>
          <v-spacer></v-spacer>
          <v-btn size="40" class="grey darken-3" @click="fecharmodel">
            <v-icon size="30" color="red">mdi-close</v-icon>
          </v-btn>
        </v-toolbar>

        <form @submit.prevent="salvar()" ref="form"
          lazy-validation class="py-4">
          <v-select
            v-model="Aluguel.livroId"
            :items="Livros"
            item-text="nomeLivro"
            item-value="id"
            :rules="livroRules"
            filled
            label="Livro"
          ></v-select>

          <v-select
            v-model="Aluguel.clienteId"
            :items="Clientes"
            item-text="nomeCliente"
            item-value="id"
            :rules="clienteRules"
            filled
            label="Cliente"
          ></v-select>

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
                  label="Previsão de entrega"
                  prepend-icon="mdi-calendar"
                  readonly
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="date"
                :min="
                  new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
                    .toISOString()
                    .substr(0, 10)
                "
                @change="save"
              ></v-date-picker>
            </v-menu>
          </div>

          <button @click="validate()" class="green darken-3 rounded-card ml-2 ">
            <v-icon size="30" color="white" class="paS-2 ml-2"
              >mdi-book-plus-outline</v-icon
            ><span class="mr-3 text-center green darken-3 white--text">
              Salvar</span
            >
          </button>
        </form>
      </v-card>
    </v-dialog>

    <v-dialog v-model="tabelaliv" width="unset" height="unset">
      <v-card
        width="200"
        height="500"
        v-model="tabelaliv"
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
                  Nome do Livro
                </th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="Livro of Livros" :key="Livro.Id" :items-per-page="5">
                <td class="text-center">{{ Livro.id }}</td>
                <td class="text-center">{{ Livro.nomeLivro }}</td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-card>
    </v-dialog>
    <v-dialog v-model="tabelacli" width="unset" height="unset">
      <v-card
        width="200"
        height="500"
        v-model="tabelaliv"
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
                  Nome do Cliente
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="Cliente of Clientes"
                :key="Cliente.id"
                :items-per-page="5"
              >
                <td class="text-center">{{ Cliente.id }}</td>
                <td class="text-center">{{ Cliente.nomeCliente }}</td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-card>
    </v-dialog>
    <v-snackbar v-model="snackbar1">
      Aluguel Deletado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar1 = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar2">
      Aluguel Adicionado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar2 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar3">
      Aluguel Entregue Com Sucesso !

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
import Cliente from "../services/Clientes";
import Alugueis from "../services/Alugueis";
import Swal from "sweetalert2/dist/sweetalert2.js";
var moment = require("moment");

export default {
  name: "Aluguel",
  components: {
    NavBar,
  },
  data() {
    return {
      Aluguel: {
        livroId: "",
        clienteId: "",
        data_Aluguel: "",
        entrega: "",
      },
      search: "",
      headers: [
        {
          text: "Id",
          align: "start",
          filterable: false,
          value: "id",
        },
        { text: "Nome do livro", value: "livro.nomeLivro" },
        { text: "Nome do cliente", value: "cliente.nomeCliente" },
        { text: "Data de Aluguel", value: "data_Aluguel" },
        { text: "Previsão de Entrega", value: "previsao" },
        { text: "Entrega do Livro", value: "entrega" },
        { text: "Status", value: "status" },
        { text: "Actions", value: "actions" },
      ],
      ultimoAluguel:[],
      activePicker: null,
      date: null,
      menu: false,
      Alugueis: [],
      Livros: [],
      Clientes: [],
      adicionar: false,
      alertcadastro: false,
      tabelaliv: false,
      tabelacli: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      clienteRules: [
        (v) => !!v || "O Cliente é obrigatório !",

      ],
      livroRules: [
        (v) => !!v || "O Livro  é obrigatório !",

      ],
    };
  },
  watch: {
    menu(val) {
      val && setTimeout(() => (this.activePicker = "YEAR"));
    },
  },
  mounted() {
    this.listar(), this.listarLivros(), this.listarClientes(); 
  },
  methods: {
    listar() {
      
      Alugueis.listar().then((resposta) => {
        (this.Alugueis = resposta.data);
        this.ultimoAluguel=this.Alugueis[this.Alugueis.length - 1];
      });
    },

    validate () {
        this.$refs.form.validate()
      },
      
    listarLivros() {
      Livro.listar().then((resposta) => {
        this.Livros = resposta.data;
      });
    },
    listarClientes() {
      Cliente.listar().then((resposta) => {
        this.Clientes = resposta.data;
      });
    },
    fecharmodel() {
      this.adicionar = false;
    },
    ModalLivros() {
      this.tabelaliv = true;
    },
    ModalClientes() {
      this.tabelacli = true;
    },
    ModalAdicionar() {
      this.adicionar = true;
    },
    salvar() {
      var data = new Date();
      var dia = String(data.getDate()).padStart(2, "0");
      var mes = String(data.getMonth() + 1).padStart(2, "0");
      var ano = data.getFullYear();
      var dataAtual = ano + "/" + mes + "/" + dia;

      var dt = moment(dataAtual).format("YYYY/MM/DD");
      var save = {
        livroId: this.Aluguel.livroId,
        clienteId: this.Aluguel.clienteId,
        data_Aluguel: dt,
        previsao: moment(this.date).format("YYYY/MM/DD"),
        entrega: "",
      };
      console.log(dt);
      console.log(save);

      Alugueis.salvar(save)
        .then((resposta) => {
          (this.Aluguel = resposta),
            this.listar(),
            console.log(this.Aluguel),
            (this.adicionar = false),
            Swal.fire({
              title: "Aluguel Feito com Sucesso ",
              icon: "success",
              confirmButtonText: "Ok",
            });
        })
        
    },
    editar(Aluguel) {
      this.Aluguel = Aluguel;
      var data = new Date();
      var dia = String(data.getDate()).padStart(2, "0");
      var mes = String(data.getMonth() + 1).padStart(2, "0");
      var ano = data.getFullYear();
      var dataAtual = ano + "/" + mes + "/" + dia;

      var dt = moment(dataAtual).format("YYYY/MM/DD");
      var save = {
        id: this.Aluguel.id,
        livroId: this.Aluguel.livroId,
        clienteId: this.Aluguel.clienteId,
        data_Aluguel: this.Aluguel.data_Aluguel,
        previsao: this.Aluguel.previsao,
        entrega: dt,
      };

      console.log(save);
      Alugueis.devolver(save).then((resposta) => {
        (this.Aluguel = resposta), this.listar(), (this.snackbar3 = true);
      });
    },

    save(date) {
      this.$refs.menu.save(date);
    },
    excluir(id) {
      Alugueis.deletar(id).then((resposta) => {
        (this.Aluguel = resposta), this.listar();
      });
    },
    
  },
};
</script>
<style>
.rounded-card {
  border-radius: 50px;
}
</style>
