<template>
<v-app class="indigo lighten-5">
  <nav-bar/>
  <v-simple-table class="py-4 mx-4">
    <template v-slot:default>
      <thead >
        <tr class="blue-grey darken-4">
          <th class="text-center white--text">
            Id
          </th>
          <th class="text-center white--text">
            Nome da Editora
          </th>
          <th class="text-center white--text">
            Cidade da Editora
          </th>
          <th class="text-center white--text">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="Editora of Editoras"
          :key="Editora.Id"
          :items-per-page="5"
        >
          <td class="text-center">{{ Editora.id }}</td>
          <td class="text-center">{{ Editora.nameEditora }}</td>
          <td class="text-center">{{ Editora.cidadeEditora }}</td>
          <td class="text-center"><v-btn class="red mr-2 rounded-card" @click="excluir(Editora.id)"><v-icon size=20>mdi-archive-remove-outline</v-icon></v-btn>
          <v-btn class="yellow rounded-card" @click="editar(Editora)"><v-icon size=20>mdi-lead-pencil</v-icon></v-btn></td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
          <div class="my-2" >
            <v-btn
              color="primary"
              dark
              fab fixed bottom right @click="ModalAdicionar"
            >
              <v-icon dark>
                 mdi-plus
               </v-icon>
            </v-btn>
          </div>
          <v-dialog v-model="adicionar" width="unset" height="unset">
            <v-card width="450" height="350" class="text-center">
                <v-toolbar class="grey darken-3">
                    <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
                    <span class="white--text">Editora</span>
                    <v-spacer></v-spacer>
                    <v-btn size=40 class="grey darken-3" @click="fecharmodel">
                    <v-icon size=30 color="red">mdi-close</v-icon>
                    </v-btn>
                </v-toolbar>
                <form @submit.prevent="salvar" class="py-4">
                    <v-text-field label="Nome da Editora" v-model="Editora.nameEditora" class="py-4 mx-2"></v-text-field>
                    <v-text-field label="Cidade" v-model="Editora.cidadeEditora" class="py-4 mx-2"></v-text-field>
                    <button type="submit" class="green darken-3 rounded-card" ><v-icon size=30 color=white class="pa-2 ">mdi-book-plus-outline</v-icon></button>
                </form>
            </v-card>
          </v-dialog>
</v-app>
</template>
<script>
import NavBar from "../components/NavBar.vue"
import Editora from "../services/Editoras"
export default ({
  name: 'Editora',
  components: {
      NavBar,
    },
  data(){
    return{
      Editora: {
        id: '',
        nameEditora: '',
        cidadeEditora: ''
      },
      Editoras:[],
      adicionar : false,
      alertcadastro : false
    }
  },
          mounted(){
            this.listar()
      },
        methods:{
              listar(){
                   Editora.listar().then(resposta =>{
                   this.Editoras = resposta.data
                    })
              },
              fecharmodel(){
                this.adicionar = false
              },
              ModalAdicionar(){
                this.adicionar = true
              },
              salvar(){
                if(this.Editora.id == null){
                 Editora.salvar(this.Editora).then(resposta =>{
                  this.Editora = resposta,
                  this.listar(),
                  this.adicionar = false
                   }) 
                }else{
                Editora.atualizar(this.Editora).then(resposta =>{
                  this.Editora = resposta,
                  this.listar(),
                  this.adicionar = false
                   }) 
                }
                
              },
              excluir(id){
                  Editora.deletar(id).then(resposta =>{
                    this.Editora = resposta,
                    this.listar()
                  })
              },
              editar(Editora){
                this.Editora = Editora,
                this.adicionar = true
              }

        },
})
</script>
<style>
.rounded-card{
    border-radius:50px;
}
</style>