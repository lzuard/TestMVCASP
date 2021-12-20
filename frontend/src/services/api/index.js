import api from './axiosInstance'

export const authorizeUser = (payload) => {
  return api.post('/Employee/auth', payload).then(({ data }) => data)
}

const getAgents = (payload) => {
  return api.get('/agents', payload).then(({ data }) => {
    console.log(data)
  })
}

const createAgent = (payload) => {
  return api.post('/agents', payload).then(({ data }) => {
    console.log(data)
  })
}

const getTTN = (payload) => {
  return api.get('/ttn', payload).then(({ data }) => {
    console.log(data)
  })
}

const createTTN = (payload) => {
  return api.post('/ttn', payload).then(({ data }) => {
    console.log(data)
  })
}

export default {
  authorizeUser,
  agents: {
    getAgents,
    createAgent
  },
  ttn: {
    getTTN,
    createTTN
  }
}
