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
            Nome do Cliente
          </th>
          <th class="text-center white--text">
            Cidade 
          </th>
          <th class="text-center white--text">
            Endereço 
          </th>
          <th class="text-center white--text">
            Email 
          </th>
          <th class="text-center white--text">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="Cliente of Clientes"
          :key="Cliente.Id"
          :items-per-page="5"
        >
          <td class="text-center">{{ Cliente.id }}</td>
          <td class="text-center">{{ Cliente.nomeCliente }}</td>
          <td class="text-center">{{ Cliente.cidadeCliente }}</td>
          <td class="text-center">{{ Cliente.enderecoCliente }}</td>
          <td class="text-center">{{ Cliente.emailCliente }}</td>
          <td class="text-center"><v-btn class="red mr-2 rounded-card" @click="excluir(Cliente.id)"><v-icon size=20>mdi-archive-remove-outline</v-icon></v-btn>
          <v-btn class="yellow rounded-card" @click="editar(Cliente)"><v-icon size=20>mdi-lead-pencil</v-icon></v-btn></td>
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
            <v-card width="490" height="520" class="text-center rounded-card">
                <v-toolbar class="grey darken-3">
                    <span class="dark ml-2 mr-1"><b>Cadastrar </b></span>
                    <span class="white--text">Cliente</span>
                    <v-spacer></v-spacer>
                    <v-btn size=40 class="grey darken-3" @click="fecharmodel">
                    <v-icon size=30 color="red">mdi-close</v-icon>
                    </v-btn>
                </v-toolbar>
                <form @submit.prevent="salvar" class="py-4">
                    <v-text-field label="Nome do Cliente" v-model="Cliente.nomeCliente" class="py-4 mx-2" :rules="nameRules" :counter="30"></v-text-field>
                    <v-text-field label="Cidade" v-model="Cliente.cidadeCliente" class="py-4 mx-2" :rules="cidadeRules" :counter="30"></v-text-field>
                    <v-text-field label="Endereço" v-model="Cliente.enderecoCliente" class="py-4 mx-2" :rules="enderecoRules" :counter="30"></v-text-field>
                    <v-text-field label="Email" v-model="Cliente.emailCliente" class="py-4 mx-2" :rules="emailRules"></v-text-field>
                    <button type="submit" class="green darken-3 rounded-card" ><v-icon size=30 color=white class="pa-2 ">mdi-book-plus-outline</v-icon></button>
                </form>
            </v-card>
          </v-dialog>

          <v-snackbar
      v-model="snackbar1"
    >
      Cliente Deletado Com Sucesso !

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
      Cliente Adicionado Com Sucesso !

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
      Cliente Atualizado Com Sucesso !

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
import Cliente from "../services/Clientes"
export default ({
  name: 'Cliente',
  components: {
      NavBar,
    },
  data(){
    return{
      Cliente: {
        id: '',
        nameEditora: '',
        cidadeEditora: '',
        enderecoCliente:'',
        emailCliente:''
      },
      Clientes:[],
      adicionar : false,
      alertcadastro : false,
      snackbar1: false,
      snackbar2: false,
      snackbar3: false,
      nameRules:[
          v => !!v || 'O Nome do Cliente é obrigatório',
          v => v.length >= 3 || 'O Nome do Cliente não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Nome do Cliente não pode ter mais que 30 characters',
      ],
      cidadeRules:[
          v => !!v || 'A Cidade é obrigatória',
          v => v.length >= 3 || 'A Cidade não pode ter menos que 3 characters',
        v => v.length <= 30 || 'A Cidade não pode ter mais que 30 characters',
      ],
      enderecoRules:[
          v => !!v || 'O Endereço é obrigatória',
          v => v.length >= 3 || 'O Endereço não pode ter menos que 3 characters',
        v => v.length <= 30 || 'O Endereço não pode ter mais que 30 characters',
      ],
      emailRules:[
        v => !!v || 'O Email é obrigatório',
          v => v.length >= 3 || 'O Email não pode ter menos que 3 characters',
        v => /.+@.+\..+/.test(v) || 'E-mail precisa ser válido !'
      ]
    }
  },
          mounted(){
            this.listar()
      },
        methods:{
              listar(){
                   Cliente.listar().then(resposta =>{
                   this.Clientes = resposta.data
                    })
              },
              fecharmodel(){
                this.adicionar = false
              },
              ModalAdicionar(){
                this.adicionar = true
              },
              salvar(){
                if(this.Cliente.id == null){
                 Cliente.salvar(this.Cliente).then(resposta =>{
                  this.Cliente = resposta,
                  this.listar(),
                  this.adicionar = false,
                  this.snackbar2= true
                   }) 
                }else{
                Cliente.atualizar(this.Cliente).then(resposta =>{
                  this.Cliente = resposta,
                  this.listar(),
                  this.adicionar = false,
                  this.snackbar3= true
                   }) 
                }
                
              },
              excluir(id){
                  Cliente.deletar(id).then(resposta =>{
                    this.Cliente = resposta,
                    this.listar(),
                    this.snackbar1= true
                  })
              },
              editar(Cliente){
                this.Cliente = Cliente,
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