import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://unlucky-baboon-91.loca.lt/api/',
    JSON: true,
})