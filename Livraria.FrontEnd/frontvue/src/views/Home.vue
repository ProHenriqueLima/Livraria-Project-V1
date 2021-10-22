<template>
  <v-app>
    <nav-bar/>
    <v-carousel v-model="model">
    <v-carousel-item  >
      <v-sheet
        height="100%"
        tile
      >
        <v-row
          class="fill-height"
          align="center"
          justify="center"
        >
          <div class="text-h2">
            Oi
          </div>
        </v-row>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>
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