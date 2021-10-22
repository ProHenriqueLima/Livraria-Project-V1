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
            Lançamento
          </th>
          <th class="text-center white--text">
            Autor 
          </th>
          <th class="text-center white--text">
            Quantidade 
          </th>
          <th class="text-center white--text">
            Editora
          </th>
          <th class="text-center white--text">
            Ações
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
          <td class="text-center">{{ Livro.lancamentoLivro }}</td>
          <td class="text-center">{{ Livro.autorLivro }}</td>
          <td class="text-center">{{ Livro.quantidade }}</td>
          <td class="text-center">{{ Livro.editora.nameEditora }}</td>
          <td class="text-center"><v-btn class="red mr-2 rounded-card" @click="excluir(Livro.id)"><v-icon size=20>mdi-archive-remove-outline</v-icon></v-btn>
          <v-btn class="yellow rounded-card" @click="editar(Livro)"><v-icon size=20>mdi-lead-pencil</v-icon></v-btn></td>
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
                    <span class="white--text">Livro</span>
                    <v-spacer></v-spacer>
                    <v-btn size=40 class="grey darken-3" @click="fecharmodel">
                    <v-icon size=30 color="red">mdi-close</v-icon>
                    </v-btn>
                </v-toolbar>

                <form @submit.prevent="salvar" class="py-4">
                    <v-text-field label="Nome do Livro" v-model="Livro.nomeLivro" class="py-4 mx-2" :rules="nomeRules" :counter="30"></v-text-field>
                    <v-btn class="grey darken-3 white--text rounded-card " @click="modalCalendario()" :rules="lancamentoRules">Lançamento</v-btn>
                    <v-text-field label="Autor" v-model="Livro.autorLivro" class="py-2 mx-2" :rules="autorRules"></v-text-field>
                    <v-text-field label="Quantidade" v-model="Livro.quantidade" class="py-2 mx-2" :rules="quantidadeRules"></v-text-field>
                    <v-text-field label="Editora Id" v-model="Livro.editoraID" class="py-2 mx-2" :rules="editoraRules"></v-text-field>
                    <v-btn class=" white--text rounded-card grey darken-3" @click="ModalEditoras()">Ver Lista de Editoras</v-btn><p/>
                    <button type="submit" class="green darken-3 rounded-card ml-2 " ><v-icon size=30 color=white class="pa-2 ml-2">mdi-book-plus-outline</v-icon><span class="mr-3 text-center green darken-3 white--text"> Salvar</span></button>
                </form>
            </v-card>
          </v-dialog>


          <v-dialog v-model="tabeladata" width="unset" height="unset">
                      <v-card  width="280" height="400">
                        <v-date-picker
                          v-model="Livro.lancamentoLivro"
                          color="grey darken-3"
                        ></v-date-picker> 
                    </v-card>
                    </v-dialog> 

          

          <v-dialog v-model="tabelaedit" width="unset" height="unset">
              <v-card width="200" height="500" v-model="tabelaedit" class="text-center rounded-card">
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
                  </tr>
                 </tbody>
                </template>
                </v-simple-table>
              </v-card>
          </v-dialog>
          <v-snackbar
      v-model="snackbar1"
    >
      Livro Deletado Com Sucesso !

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
      Livro Adicionado Com Sucesso !

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
      Livro Atualizado Com Sucesso !

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
import Editora from "../services/Editoras"
export default ({
  name: 'Livro',
  components: {
      NavBar,
    },
  data(){
    return{
      Livro: {
        nomeLivro: '',
        lancamentoLivro: '',
        autorLivro:'',
        quantidade: '',
        editoraID: '',
      },

      Livros:[],
      Editoras:[],
      adicionar : false,
      alertcadastro : false,
      tabelaedit: false,
      tabeladata: false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      nomeRules:[
          v => !!v || 'O Nome do Livro é obrigatório',
          v => v.length >= 3 || 'O Nome do Livro não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Nome do Livro não pode ter mais que 30 characters',
      ],
      autorRules:[
          v => !!v || 'O Nome do autor é obrigatório',
          v => v.length >= 3 || 'O Nome do autor não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Nome do autor não pode ter mais que 30 characters',
      ],
      lancamentoRules:[
          v => !!v || 'O Lançamento é obrigatório',
          v => v.length >= 3 || 'O Lançamento não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Lançamento não pode ter mais que 30 characters',
      ],
      editoraRules:[
          v => !!v || 'O Editora ID é obrigatório e tem que ser válido !',
          v => !isNaN( v ) || ' O Editora ID pode conter apenas números !'

      ],
      quantidadeRules:[
          v => !!v || 'A quantidade é obrigatória e tem que ser válida !',
          v => !isNaN( v ) || ' A quantidade pode conter apenas números !'
      ],
    }
  },
          mounted(){
            this.listar(),
            this.listarEditora()
      },
        methods:{
              modalCalendario(){
                  this.tabeladata=true
              },
              listar(){
                   
                   Livro.listar().then(resposta =>{
                   this.Livros = resposta.data
                    })
              },
              listarEditora(){
                   
                   Editora.listar().then(resposta =>{
                   this.Editoras = resposta.data
                    })
              },
              fecharmodel(){
                this.adicionar = false
              },
              ModalEditoras(){
                this.tabelaedit = true
              },
              ModalAdicionar(){
                this.adicionar = true
              },
              salvar(){
                if(this.Livro.id == null){
                 Livro.salvar(this.Livro).then(resposta =>{
                  this.Livro = resposta,
                  this.listar(),
                  this.adicionar = false,
                  this.snackbar2 = true
                   }) 
                }else{
                Livro.atualizar(this.Livro).then(resposta =>{
                  this.Livro = resposta,
                  this.listar(),
                  this.adicionar = false
                   this.snackbar3 = true
                   }) 
                }
                
              },
              excluir(id){
                  Livro.deletar(id).then(resposta =>{
                    this.Livro = resposta,
                    this.listar(),
                    this.snackbar1= true
                  })
              },
              editar(Livro){
                this.Livro = Livro,
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