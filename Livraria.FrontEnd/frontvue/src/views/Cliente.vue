<template>
  <v-app class="grey darken-4">
    <nav-bar />

    <v-card class="mx-3 mt-4">
      <v-card-title>
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Search"
          single-line
          hide-details
        ></v-text-field>
      </v-card-title>
      <v-data-table :headers="headers" :items="Clientes" :search="search">
        <template v-slot:[`item.actions`]="{ item }">
          <v-icon small class="mr-2" @click="editar(item)">
            mdi-pencil
          </v-icon>
          <v-icon small @click="excluir(item.id)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
    </v-card>

    <div class="my-2">
      <v-btn color="purple" dark fab fixed bottom right @click="ModalAdicionar">
        <v-icon dark>
          mdi-plus
        </v-icon>
      </v-btn>
    </div>
    <v-dialog v-model="adicionar" width="unset" height="unset">
      <v-card width="490" height="520" class="text-center rounded-card">
        <v-toolbar class="grey darken-3">
          <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
          <span class="white--text">Cliente</span>
          <v-spacer></v-spacer>
          <v-btn size="40" class="grey darken-3" @click="fecharmodel">
            <v-icon size="30" color="red">mdi-close</v-icon>
          </v-btn>
        </v-toolbar>
        <form @submit.prevent="salvar" class="py-4">
          <v-text-field
            label="Nome do Cliente"
            v-model="Cliente.nomeCliente"
            class="py-4 mx-2"
            :rules="nameRules"
            :counter="30"
          ></v-text-field>
          <v-text-field
            label="Cidade"
            v-model="Cliente.cidadeCliente"
            class="py-4 mx-2"
            :rules="cidadeRules"
            :counter="30"
          ></v-text-field>
          <v-text-field
            label="Endereço"
            v-model="Cliente.enderecoCliente"
            class="py-4 mx-2"
            :rules="enderecoRules"
            :counter="30"
          ></v-text-field>
          <v-text-field
            label="Email"
            v-model="Cliente.emailCliente"
            class="py-4 mx-2"
            :rules="emailRules"
          ></v-text-field>
          <button type="submit" class="green darken-3 rounded-card">
            <v-icon size="30" color="white" class="pa-2 "
              >mdi-book-plus-outline</v-icon
            >
          </button>
        </form>
      </v-card>
    </v-dialog>

    <v-snackbar v-model="snackbar1">
      Cliente Deletado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar1 = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar2">
      Cliente Adicionado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar2 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar3">
      Cliente Atualizado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn color="green" text v-bind="attrs" @click="snackbar3 = false">
          Ok !
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbarErro">
      Confira Todos os Campos !

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    
  </v-app>
</template>
<script>
import NavBar from "../components/NavBar.vue";
import Swal from "sweetalert2/dist/sweetalert2.js";

import Cliente from "../services/Clientes";
export default {
  name: "Cliente",
  components: {
    NavBar,
  },
  data() {
    return {
      Cliente: {
        nameEditora: "",
        cidadeEditora: "",
        enderecoCliente: "",
        emailCliente: "",
      },
      search: "",
      Clientes: [],
      headers: [
        {
          text: "Id",
          align: "start",
          filterable: false,
          value: "id",
        },
        { text: "Nome do Cliente", value: "nomeCliente" },
        { text: "Cidade", value: "cidadeCliente" },
        { text: "Endereço", value: "enderecoCliente" },
        { text: "Email", value: "emailCliente" },
        { text: "Actions", value: "actions" },
      ],
      adicionar: false,
      alertcadastro: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      snackbarErro: false,
      nameRules: [
        (v) => !!v || "O Nome do Cliente é obrigatório",
        (v) =>
          (v && v.length >= 3) ||
          "O Nome do Cliente não pode ter menos que 3 characters",
        (v) =>
          (v && v.length <= 30) ||
          "O Nome do Cliente não pode ter mais que 30 characters",
      ],
      cidadeRules: [
        (v) => !!v || "A Cidade é obrigatória",
        (v) =>
          (v && v.length >= 3) ||
          "A Cidade não pode ter menos que 3 characters",
        (v) =>
          (v && v.length <= 30) ||
          "A Cidade não pode ter mais que 30 characters",
      ],
      enderecoRules: [
        (v) => !!v || "O Endereço é obrigatória",
        (v) =>
          (v && v.length >= 3) ||
          "O Endereço não pode ter menos que 3 characters",
        (v) =>
          (v && v.length <= 30) ||
          "O Endereço não pode ter mais que 30 characters",
      ],
      emailRules: [
        (v) => !!v || "O Email é obrigatório",
        (v) =>
          (v && v.length >= 3) || "O Email não pode ter menos que 3 characters",
        (v) => /.+@.+\..+/.test(v) || "E-mail precisa ser válido !",
      ],
    };
  },
  mounted() {
    this.listar();
  },
  methods: {
    listar() {
      Swal.fire({
            title: "Seja bem-vindo ",
            text: "Página dos Clientes , sinta-se a vontade !",
           
            confirmButtonText: "Ok",
          })
      Cliente.listar().then((resposta) => {
        this.Clientes = resposta.data;
      });
    },
    fecharmodel() {
      this.adicionar = false;
    },
    ModalAdicionar() {
      this.adicionar = true;
    },
    salvar() {
      if (this.Cliente.id == null) {
        Cliente.salvar(this.Cliente)
          .then((resposta) => {
            (this.Cliente = resposta),
              this.listar(),
              (this.adicionar = false),
              (this.snackbar2 = true);
          })
          .catch(alert("Verifique todos os campos !"));
      } else {
        Cliente.atualizar(this.Cliente)
          .then((resposta) => {
            (this.Cliente = resposta),
              this.listar(),
              (this.adicionar = false),
              (this.snackbar3 = true);
          })
          .catch(alert("Verifique todos os campos !"));
      }
    },
    excluir(id) {
      Cliente.deletar(id).then((resposta) => {
        (this.Cliente = resposta), this.listar(), (this.snackbar1 = true);
      });
    },
    editar(Cliente) {
      (this.Cliente = Cliente), (this.adicionar = true);
    },
  },
};
</script>
<style>
.rounded-card {
  border-radius: 50px;
}
</style>
