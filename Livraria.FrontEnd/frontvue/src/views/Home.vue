<template>
  <v-app class="grey darken-4">
    <nav-bar />
 
    <v-carousel v-model="model" class="grey lighten-1">
      <v-carousel-item>
        <v-sheet height="100%" tile class="grey lighten-1">
          <v-row class="fill-height" align="center" justify="center">
            <v-img class="py-1 ml-4" src="../assets/inicio02.png"></v-img>
          </v-row>
        </v-sheet>
      </v-carousel-item>
      <v-carousel-item>
        <v-sheet height="100%" tile class="grey lighten-1">
          <v-row class="fill-height" align="center" justify="center">
            <v-img class="py-1 ml-4" src="../assets/inicio03.png"></v-img>
          </v-row>
        </v-sheet>
      </v-carousel-item>
    </v-carousel>
    <hr class="my-3">
    <ul class="absolute">
      <row>
        <v-card
          :loading="loading"
          class="mx-auto my-12 deep-purple accent-3 text-center"
          width="280"
          height="150"
        >
          <div>
            <v-card-title class="ml-3 white--text text-center"
              ><h3>
                Número de Alugueis <br />
                Feitos
              </h3>
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
          class="mx-auto my-12 deep-purple accent-3 text-center"
          width="280"
          height="150"
        >
          <div>
            <v-card-title class="ml-3 white--text text-center"
              ><h3>Último Livro Alugado</h3>
            </v-card-title>
          </div>
          <div>
            <h1 class=" text-center white--text ">
              <b>{{ this.Alugueis[Alugueis.length - 1].livro.nomeLivro }}</b>
            </h1>
          </div>
        </v-card>
      </row>
    </ul>
    <hr>
    <v-card
          :loading="loading"
          class="mx-3  grey darken-4 accent-3 text-center"
          width=100%
          height=250
        >
        <pie-chart :data="[['Blueberry', 44], ['Strawberry', 23]]"></pie-chart>
        </v-card>

    
  </v-app>
</template>

<script>
import NavBar from "../components/NavBar.vue";
import Alugueis from "../services/Alugueis.js";
import Livro from "../services/Livros";

export default {
  name: "Home",
  components: {
    NavBar,
  },
  data() {
    return {
      Alugueis: [],
      Livros: [],
    };
  },
  mounted() {
    this.listar();
  },
  methods: {
    listar() {
      Alugueis.listar().then((resposta) => {
        (this.Alugueis = resposta.data), console.log(this.Alugueis);
      });
    },
    listarLivros() {
      Livro.listar().then((resposta) => {
        this.Livros = resposta.data;
      });
    },
  },
};
</script>
