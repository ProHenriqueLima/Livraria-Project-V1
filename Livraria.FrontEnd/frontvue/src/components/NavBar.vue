<template>

  <nav >
      <v-toolbar class="black">
         <v-toolbar-title>
           <a href="/"><v-img class="py-1 MT-1 ml-4" max-height="150" max-width="350" src="../assets/LogoWda.png"></v-img></a>
        </v-toolbar-title>
          <v-spacer></v-spacer>
        <div class="text-center black">
            <a href="/Editora" class="text-decoration-none mr-2"><v-btn depressed class="text-center black white--text">
                <v-icon class="purple--text">mdi-book</v-icon>Editoras
             </v-btn></a>
             <a href="/Livro" class="text-decoration-none mr-2"><v-btn depressed class="text-center black white--text">
               <v-icon class="purple--text">mdi-book-open-page-variant</v-icon>Livros
             </v-btn></a>
            <a href="/Cliente" class="text-decoration-none mr-2"> <v-btn depressed class="text-center black white--text">
              <v-icon class="purple--text">mdi-account</v-icon> Clientes
             </v-btn></a>
             <a href="/Alugueis" class="text-decoration-none mr-2"><v-btn depressed class="text-center black white--text">
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
