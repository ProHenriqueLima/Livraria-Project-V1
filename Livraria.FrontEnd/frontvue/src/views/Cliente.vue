<template>
  <v-app class="grey darken-4">
    <nav-bar />
    <v-card
      class=" my-12 purple darken-3
 text-center mx-auto"
      width="1050"
      height="50"
    >
      <h1 class="white--text mt-1 font-weight-black">
        Ultimo Cliente Cadastrado
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
            ><h3>Cliente</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoCliente.nomeCliente }}</b>
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
            ><h3>Cidade</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{ ultimoCliente.cidadeCliente }}</b>
          </h1>
        </div>
      </v-card>

      <v-card
        class=" my-5 purple darken-3
text-center ml-4"
        width="350"
        height="150"
      >
        <div>
          <v-card-title class=" white--text text-center mx-4"
            ><h3>Endereço</h3>
          </v-card-title>
        </div>
        <div>
          <h1 class=" text-center white--text ">
            <b>{{  ultimoCliente.enderecoCliente }}</b>
          </h1>
        </div>
      </v-card>
    </v-row>

    <v-card class=" mt-12 purple darken-3
 text-center mx-auto" width="1301" height="50">
      <h1 class="white--text mt-1 font-weight-black">Tabela de Clientes</h1>
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
      <v-data-table :headers="headers" :items="Clientes" :search="search">
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
      <v-btn color="purple darken-3" dark fab fixed bottom right @click="ModalAdicionar">
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


        <v-form @submit.prevent="salvar" ref="form"
          lazy-validation
          class="py-4">
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
          <button @click="validate()" class="green darken-3 rounded-card">
            <v-icon size="30" color="white" class="pa-2 "
              >mdi-book-plus-outline</v-icon
            >
          </button>
        </v-form>
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
      ultimoCliente:[],
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

    validate () {
        this.$refs.form.validate()
      },

    listar() {
      Cliente.listar().then((resposta) => {
        this.Clientes = resposta.data;
      this.ultimoCliente=this.Clientes[this.Clientes.length - 1];
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
        Cliente.salvar(this.Cliente).then((resposta) => {
          (this.Cliente = resposta),
            this.listar(),
            (this.adicionar = false),
            Swal.fire({
              title: " Sucesso",
              text: "Cliente , Adicionado com Sucesso !",
              icon: "success",
              confirmButtonText: "Ok",
            });
        })
      } else {
        Cliente.atualizar(this.Cliente).then((resposta) => {
          (this.Cliente = resposta),
            this.listar(),
            (this.adicionar = false),
            Swal.fire({
              title: "Sucesso ",
              text: "Cliente atualizado com sucesso",
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
          Cliente.verificar(id).then((resposta) => {
            this.Clientes = resposta.data;
            this.numeroaluguel = this.Editoras.length
          if(this.Clientes == 0){
            Cliente.deletar(id).then((resposta) => {
            (this.Clientes = resposta)
          });
          Swal.fire(
            "Deletado!",
            "o Cliente foi deletado com sucesso.",
            "success"
          );
           this.listar();
            }
          else{
            Swal.fire(
            "Não Deletado!",
            "O Cliente Possui "+this.numeroaluguel+" Alugueis.",
            "error"
          );
          this.listar();
          }
          });
        }
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
