import axios from 'axios'
console.log(process.env)
export default axios.create({
  baseURL: 'https://jsonplaceholder.typicode.com'
})
