<template>
  
  <nav >
    
      <v-toolbar class="grey darken-4 ">
       <div class="mx-auto">
           <v-row >
             <h1 class="purple--text ml-2">Wda</h1><h2 class="white--text">Livraria</h2>
           </v-row>
        </div>
      </v-toolbar>
      <v-toolbar class="grey darken-4">
        <div class="text-center grey darken-4 mx-auto">
            <a href="/" class="text-decoration-none mr-6"><v-btn depressed class="text-center grey darken-4 white--text">
                <v-icon class="purple--text">mdi-bookmark-multiple</v-icon>Home
             </v-btn></a>
            <a href="/Editora" class="text-decoration-none mr-6"><v-btn depressed class="text-center grey darken-4 white--text">
                <v-icon class="purple--text">mdi-book</v-icon>Editoras
             </v-btn></a>
             <a href="/Livro" class="text-decoration-none mr-6"><v-btn depressed class="text-center grey darken-4 white--text">
               <v-icon class="purple--text">mdi-book-open-page-variant</v-icon>Livros
             </v-btn></a>
            <a href="/Cliente" class="text-decoration-none mr-6"> <v-btn depressed class="text-center grey darken-4 white--text">
              <v-icon class="purple--text">mdi-account</v-icon> Clientes
             </v-btn></a>
             <a href="/Alugueis" class="text-decoration-none mr-6"><v-btn depressed class="text-center grey darken-4 white--text">
              <v-icon class="purple--text">mdi-briefcase</v-icon> Aluguel
             </v-btn></a>
         </div>
      </v-toolbar>
      <hr class="purple">
    </nav>
   

</template>

<script>
  export default {
    data: () => ({
      sheet: false,
    }),
  }
</script>
