import {http} from "./config"

export default {
    listar:() =>{
        return http.get('Aluguel')
    },
    listar2:() =>{
        return http.get('Editora')
    },
    listar3:() =>{
        return http.get('Cliente')
    },
    salvar:(Aluguel) =>{
        return http.post('Aluguel', Aluguel)
    },
    deletar:(Id) =>{
        return http.delete('Aluguel/'+Id)
    },
    atualizar:(Aluguel) =>{
        return http.put('Aluguel/'+Aluguel.id, Aluguel)
    }
}