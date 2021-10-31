import {http} from "./config"

export default {
    listar:() =>{
        return http.get('Cliente')
    },
    salvar:(Cliente) =>{
        return http.post('Cliente', Cliente)
        
    },
    deletar:(Id) =>{
        return http.delete('Cliente/'+Id)
    },
    atualizar:(Cliente) =>{
        return http.put('Cliente/'+Cliente.id, Cliente)
        
    }
}