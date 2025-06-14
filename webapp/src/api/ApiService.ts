import Axios from 'axios'

const ApiService = Axios.create({
  baseURL: 'http://localhost:5000',
})
export default ApiService

