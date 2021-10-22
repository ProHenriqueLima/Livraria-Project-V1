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
            Nome do Livro
          </th>
          <th class="text-center white--text">
            Nome do Cliente
          </th>

          <th class="text-center white--text">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="Aluguel of Alugueis"
          :key="Aluguel.Id"
          :items-per-page="5"
        >
          <td class="text-center">{{ Aluguel.id }}</td>
          <td class="text-center">{{ Aluguel.livro.nomeLivro }}</td>
          <td class="text-center">{{ Aluguel.cliente.nomeCliente }}</td>
          <td class="text-center"><v-btn class="red mr-2 rounded-card" @click="excluir(Aluguel.id)"><v-icon size=20>mdi-archive-remove-outline</v-icon></v-btn>
          <v-btn class="yellow rounded-card" @click="editar(Aluguel)"><v-icon size=20>mdi-lead-pencil</v-icon></v-btn></td>
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
            <v-card width="590" height="550" class="text-center rounded-card">
                <v-toolbar class="grey darken-3">
                    <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
                    <span class="white--text">Aluguel</span>
                    <v-spacer></v-spacer>
                    <v-btn size=40 class="grey darken-3" @click="fecharmodel">
                    <v-icon size=30 color="red">mdi-close</v-icon>
                    </v-btn>
                </v-toolbar>

                <form @submit.prevent="salvar" class="py-4">
                 
                    <v-text-field label="Livro Id" v-model="Aluguel.livroId" class="py-2 mx-2" :rules="livroRules"></v-text-field>

                    <v-text-field label="Cliente Id" v-model="Aluguel.clienteId" class="py-2 mx-2" :rules="clienteRules"></v-text-field>
                    <v-btn class=" white--text rounded-card grey darken-3" @click="ModalLivros()">Ver Lista de Livros</v-btn><p/>
                    <v-btn class=" white--text rounded-card grey darken-3" @click="ModalClientes()">Ver Lista de Clientes</v-btn><p/>
                    <button type="submit" class="green darken-3 rounded-card ml-2 " ><v-icon size=30 color=white class="pa-2 ml-2">mdi-book-plus-outline</v-icon><span class="mr-3 text-center green darken-3 white--text"> Salvar</span></button>
                </form>
            </v-card>
          </v-dialog>


         
          

          <v-dialog v-model="tabelaliv" width="unset" height="unset">
              <v-card width="200" height="500" v-model="tabelaliv" class="text-center rounded-card">
            <v-simple-table class="py-4 mx-4">
                <template v-slot:default>
                  <thead >
                    <tr class="blue-grey darken-4">
                      <th class="text-center white--text">
                        Id
                      </th>
                      <th class="text-center white--text">
                        Nome do Livro
                      </th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="Livro of Livros"
                      :key="Livro.Id"
                      :items-per-page="5"
                    >
                    <td class="text-center">{{ Livro.id }}</td>
                    <td class="text-center">{{ Livro.nomeLivro }}</td>
                  </tr>
                 </tbody>
                </template>
                </v-simple-table>
              </v-card>
          </v-dialog>
          <v-dialog v-model="tabelacli" width="unset" height="unset">
              <v-card width="200" height="500" v-model="tabelaliv" class="text-center rounded-card">
            <v-simple-table class="py-4 mx-4">
                <template v-slot:default>
                  <thead >
                    <tr class="blue-grey darken-4">
                      <th class="text-center white--text">
                        Id
                      </th>
                      <th class="text-center white--text">
                        Nome do Cliente
                      </th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="Cliente of Clientes"
                      :key="Cliente.id"
                      :items-per-page="5"
                    >
                    <td class="text-center">{{ Cliente.id }}</td>
                    <td class="text-center">{{ Cliente.nomeCliente }}</td>
                  </tr>
                 </tbody>
                </template>
                </v-simple-table>
              </v-card>
          </v-dialog>
    <v-snackbar
      v-model="snackbar1"
    >
      Aluguel Deletado Com Sucesso !

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
      Aluguel Adicionado Com Sucesso !

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
     Aluguel Atualizado Com Sucesso !

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
import Livro from "../services/Livros"
import Cliente from "../services/Clientes"
import Aluguel from "../services/Alugueis"

export default ({
  name: 'Aluguel',
  components: {
      NavBar,
    },
  data(){
    return{
      Aluguel: {
        livroId: '',
        clienteId: '',
      },
      Alugueis:[],
      Livros:[],
      Clientes:[],
      adicionar : false,
      alertcadastro : false,
      tabelaliv: false,
      tabelacli: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      clienteRules: [
         v => !!v || 'O Cliente ID é obrigatório e tem que ser válido !',
         v => !isNaN( v ) || ' O Cliente ID pode conter apenas números !'
      ],
      livroRules: [
         v => !!v || 'O Livro ID é obrigatório e tem que ser válido !',
         v => !isNaN( v ) || ' O Livro ID pode conter apenas números !'
      ],
      
    }
  },
          mounted(){
            this.listar(),
            this.listarLivros(),
            this.listarClientes()
      },
        methods:{
              listar(){
                   
                   Aluguel.listar().then(resposta =>{
                   this.Alugueis = resposta.data,
                   console.log( this.Alugueis )
                    })
              },
              listarLivros(){
                   
                   Livro.listar().then(resposta =>{
                   this.Livros = resposta.data
                    })
              },
              listarClientes(){
                   
                   Cliente.listar().then(resposta =>{
                   this.Clientes = resposta.data
                    })
              },
              fecharmodel(){
                this.adicionar = false
              },
              ModalLivros(){
                this.tabelaliv = true
              },
              ModalClientes(){
                this.tabelacli = true
              },
              ModalAdicionar(){
                this.adicionar = true
              },
              salvar(){
                if(this.Aluguel.id == null){
                 Aluguel.salvar(this.Aluguel).then(resposta =>{
                  this.Aluguel = resposta,
                  this.listar(),
                  console.log(this.Aluguel),
                  this.adicionar = false,
                  this.snackbar2 = true
                   }) 
                }else{
                Livro.atualizar(this.Aluguel).then(resposta =>{
                  this.Aluguel = resposta,
                  this.listar(),
                  this.adicionar = false,
                  this.snackbar3 = true
                   }) 
                }
                
              },
              excluir(id){
                  Aluguel.deletar(id).then(resposta =>{
                    this.Aluguel = resposta,
                    this.listar(),
                    this.snackbar1 = true
                  })
              },
              editar(Aluguel){
                this.Aluguel = Aluguel,
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