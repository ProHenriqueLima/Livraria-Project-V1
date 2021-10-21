<template>
  <v-app>
    <nav-bar/>
    
  </v-app>
</template>

<script>
  import NavBar from "../components/NavBar.vue"

  export default {
    name: 'Home',

    components: {
      NavBar,
    },
  }
</script>