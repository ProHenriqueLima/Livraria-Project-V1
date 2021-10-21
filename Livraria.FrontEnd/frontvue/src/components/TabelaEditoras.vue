<template>
  <v-simple-table class="py-4 ml-4 mr-4">
    <template v-slot:default>
      <thead >
        <tr class="grey darken-4">
          <th class="text-center white--text">
            Id
          </th>
          <th class="text-center white--text">
            Nome da Editora
          </th>
          <th class="text-center white--text">
            Cidade da Editora
          </th>
          <th class="text-center ">
            
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="Editora of Editoras"
          :key="Editora.Id"
        >
          <td class="text-center">{{ Editora.id }}</td>
          <td class="text-center">{{ Editora.nameEditora }}</td>
          <td class="text-center">{{ Editora.cidadeEditora }}</td>
          <td class="text-center"><v-btn class="red mr-2">Excluir</v-btn>
          <v-btn class="yellow">Atualizar</v-btn></td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>

</template>
<script>
import Editora from "../services/Editoras"
  export default {
    data () {
      return {
        Editoras: []
      }
    },
    name :"TabelaEditoras",
    mounted(){
    Editora.listar().then(resposta =>{
      console.log(resposta.data)
      this.Editoras = resposta.data
       })
    }
    
  }
</script>