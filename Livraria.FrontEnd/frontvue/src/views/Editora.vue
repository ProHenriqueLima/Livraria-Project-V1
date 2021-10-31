<template>
<v-app class="grey darken-4">
  <nav-bar/>
  
 <v-card class="mx-3 mt-4">
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        hide-details
      ></v-text-field>
    </v-card-title>
    <v-data-table
      :headers="headers"
      :items="Editoras"
      :search="search"
    >
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editar(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="excluir(item.id)"
      >
        mdi-delete
      </v-icon>
    </template>
    </v-data-table>
  </v-card>
          <div class="my-2" >
            <v-btn
              color="purple"
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
                    <v-text-field label="Nome da Editora" v-model="Editora.nameEditora" class="py-4 mx-2"  :rules="nameRules" :counter="30"></v-text-field>
                    <v-text-field label="Cidade" v-model="Editora.cidadeEditora" class="py-4 mx-2" :rules="cidadeRules" :counter="30"></v-text-field>
                    <button type="submit" class="green darken-3 rounded-card" ><v-icon size=30 color=white class="pa-2 ">mdi-book-plus-outline</v-icon></button>
                </form>
            </v-card>
          </v-dialog>

          <v-snackbar
      v-model="snackbar1"
    >
      Editora Deletado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn
          color="red"
          text
          v-bind="attrs"
          @click="snackbar1 = false"
        >
          Close
        </v-btn>
      </template>
          </v-snackbar>
          <v-snackbar
      v-model="snackbar2"
    >
      Editora Adicionado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn
          color="green"
          text
          v-bind="attrs"
          @click="snackbar2 = false"
        >
          Ok !
        </v-btn>
      </template>
          </v-snackbar>
           <v-snackbar
      v-model="snackbar3"
    >
      Editora Atualizado Com Sucesso !

      <template v-slot:action="{ attrs }">
        <v-btn
          color="green"
          text
          v-bind="attrs"
          @click="snackbar3 = false"
        >
          Ok !
        </v-btn>
      </template>
           </v-snackbar>
</v-app>
</template>
<script>
import NavBar from "../components/NavBar.vue"
import Editora from "../services/Editoras"
import Swal from "sweetalert2/dist/sweetalert2.js";

export default ({
  name: 'Editora',
  components: {
      NavBar,
    },
  data(){
    return{
      Editora: {
        nameEditora: '',
        cidadeEditora: ''
      },
      headers: [
          {
            text: 'Id',
            align: 'start',
            filterable: false,
            value: 'id',
          },
          { text: 'Nome da Editora', value: 'nameEditora' },
          { text: 'Cidade da Editora', value: 'cidadeEditora' },
          { text: 'Actions', value: 'actions'},

        ],
        search: '',
      Editoras:[],
      adicionar : false,
      alertcadastro : false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,

      nameRules:[
          v => !!v || 'O Nome da Editora é obrigatório',
          v => v.length >= 3 || 'O Nome da Editora não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Nome da Editora não pode ter mais que 30 characters',
      ],
      cidadeRules:[
          v => !!v || 'A Cidade é obrigatória',
          v => v.length >= 3 || 'A Cidade não pode ter menos que 3 characters',
        v => v.length <= 30 || 'A Cidade não pode ter mais que 30 characters',
      ]
    }
  },
          mounted(){
            this.listar()
      },
        methods:{
              listar(){
                Swal.fire({
            title: "Seja bem-vindo ",
            text: "Página das editoras , sinta-se a vontade !",
            icon: "info",
            confirmButtonText: "Ok",
          })
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
                  this.snackbar2= true
                   }) 
                }else{
                Editora.atualizar(this.Editora).then(resposta =>{
                  this.Editora = resposta,
                  this.listar(),
                  this.adicionar = false
                  this.snackbar3= true
                   }) 
                }
                
              },
              excluir(id){
                
                  Editora.deletar(id).then(resposta =>{
                    this.Editora = resposta,
                    this.listar()
                    this.snackbar1= true
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