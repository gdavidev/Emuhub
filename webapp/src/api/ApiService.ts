import Axios from 'axios'

const ApiService = Axios.create({
  baseURL: `http://${window.location.hostname}:5000`,
})
export default ApiService

