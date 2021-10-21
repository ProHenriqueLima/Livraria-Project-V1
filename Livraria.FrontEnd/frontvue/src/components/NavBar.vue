<template>

  <nav>
      <v-toolbar class="grey darken-3">
         <v-toolbar-title>
           <v-img class="py-1 ml-4" max-height="150" max-width="250" src="../assets/LogoWda.png"></v-img>
        </v-toolbar-title>
          <v-spacer></v-spacer>
        <div class="text-center grey darken-3">
            <a href="/Editora" class="text-decoration-none mr-2"><v-btn depressed class="text-center grey darken-3 white--text">
                <v-icon>mdi-border-color</v-icon>Editoras
             </v-btn></a>
             <a href="#" class="text-decoration-none mr-2"><v-btn depressed class="text-center grey darken-3 white--text">
               <v-icon>mdi-book</v-icon>Livros
             </v-btn></a>
            <a href="#" class="text-decoration-none mr-2"> <v-btn depressed class="text-center grey darken-3 white--text">
              <v-icon>mdi-account</v-icon> Clientes
             </v-btn></a>
             <a href="#" class="text-decoration-none mr-2"><v-btn depressed class="text-center grey darken-3 white--text">
              <v-icon>mdi-briefcase</v-icon> Aluguel
             </v-btn></a>
         </div>
      </v-toolbar>
    </nav>
   

</template>

<script>
  export default {
    data: () => ({
      sheet: false,
    }),
  }
</script>
