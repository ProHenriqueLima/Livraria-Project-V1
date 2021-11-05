import {http} from "./config"

export default {
    listar:() =>{
        return http.get('Livro')
    },
    verificar:(id)=>{
        return http.get('Aluguel/Livro/'+id)
    },
    listar2:() =>{
        return http.get('Editora')
    },
    salvar:(Livro) =>{
        return http.post('Livro', Livro)
    },
    deletar:(Id) =>{
        return http.delete('Livro/'+Id)
    },
    atualizar:(Livro) =>{
        return http.put('Livro/'+Livro.id, Livro)
    }
}