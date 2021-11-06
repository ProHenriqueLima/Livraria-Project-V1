<template>
  <v-app class="grey darken-3">
    <nav-bar />
 
    <!-- <v-carousel v-model="model" class="grey lighten-1">
      <v-carousel-item>
        <v-sheet height="100%" tile class="grey lighten-1">
          <v-row class="fill-height" align="center" justify="center">
            <v-img class="py-1 ml-4" src="../assets/inicio03.png"></v-img>
          </v-row>
        </v-sheet>
      </v-carousel-item>
    </v-carousel> -->
 
      <v-card
      class=" mt-6 mv-2 grey darken-4 text-center mx-auto"
 
      height="50"
    >
      <h1 class="white--text mt-1 mb-1 grey darken-4 ">
        DashBoard
      </h1>
    </v-card>
      <v-row class="mx-auto">
        <v-card
          :loading="loading"
          class=" my-5 ml-4 mr-4 deep-purple darken-3 text-center"
          width="350"
          height="150"
        >
          <div>
            <v-card-title class="ml-3 white--text text-center"
              ><v-icon class="white--text mr-2">mdi-briefcase</v-icon> Alugueis
            </v-card-title>
          </div>
          <div>
            <h1 class=" text-center white--text ">
              <b>{{ this.Alugueis.length }}</b>
            </h1>
          </div>
        </v-card>
        <v-card
          :loading="loading"
          class=" my-5 ml-4 mr-4 deep-purple darken-3 text-center"
          width="350"
          height="150"
        >
          <div>
            <v-card-title class="ml-3 white--text text-center"
              > <v-icon class="white--text mr-2">mdi-account</v-icon> Clientes
            </v-card-title>
          </div>
          <div>
            <h1 class=" text-center white--text ">
              <b>{{ this.Clientes.length }}</b>
            </h1>
          </div>     
        </v-card>
        <v-card
          :loading="loading"
          class=" my-5 ml-4 mr-4 deep-purple darken-3 text-center"
          width="350"
          height="150"
        >
          <div>
            <v-card-title class="ml-3 white--text text-center"
              > <v-icon class="white--text mr-2">mdi-book-open-page-variant</v-icon> Livros
            </v-card-title>
          </div>
          <div>
            <h1 class=" text-center white--text ">
              <b>{{ this.Livros.length }}</b>
            </h1>
          </div>
        </v-card>
      </v-row>
      <v-card
      class="  purple darken-3 text-center mx-auto"
      width="1120"
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
        class="ml-3 my-5 purple darken-3 text-center ml-4"
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
  
    <hr>
     <graficos /> 

    
  </v-app>
</template>

<script>
import NavBar from "../components/NavBar.vue";
import Alugueis from "../services/Alugueis.js";
import Clientes from "../services/Clientes.js";
import Livros from "../services/Livros";
 import Graficos from "../components/Graficos"
export default {
  name: "Home",
  components: {
     NavBar,Graficos
  },
  data() {
    return {
      Alugueis: [],
      Livros: [],
      Clientes:[],
    };
  },
  mounted() {
    this.listar();
  },
  methods: {
    listar() {
      Alugueis.listar().then((resposta) => {
        (this.Alugueis = resposta.data), console.log(this.Alugueis);
        this.ultimoAluguel=this.Alugueis[this.Alugueis.length - 1];
      });
      Livros.listar().then((resposta) => {
        this.Livros = resposta.data;
      });
      Clientes.listar().then((resposta) => {
        this.Clientes = resposta.data;
      });
    },
  },
};
</script>
