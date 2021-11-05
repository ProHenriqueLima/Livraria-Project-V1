<template>
    <div class="mt-4 mb-6 mx-auto white--text"> 
      <v-card  width="500" height="250" class="grey lighten-1 ">
        <v-card  width="480" height="250" class="grey lighten-1 mx-auto mt-2">
      <apexchart width="400" type="donut" :options="options" :series="series" class="text" ></apexchart>
        </v-card>
      </v-card>
    </div>
</template>
<script>
  
  export default {
    data: function() {
    return {
      options: {
        
        labels: ['Devolvidos', 'Não Devolvidos'], color:  '#FFFFFF',
       
      },
      series: [0, 1]
    }
  }
  }
</script>
