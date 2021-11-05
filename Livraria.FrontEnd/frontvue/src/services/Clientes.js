import {http} from "./config"

export default {
    listar:() =>{
        return http.get('Cliente')
    },
    salvar:(Cliente) =>{
        return http.post('Cliente', Cliente)
    },
    verificar:(id)=>{
        return http.get('Aluguel/Cliente/'+id)
    },
    
    deletar:(Id) =>{
        return http.delete('Cliente/'+Id)
    },
    atualizar:(Cliente) =>{
        return http.put('Cliente/'+Cliente.id, Cliente)
        
        
    }
}