import api from './axiosInstance'

export const authorizeUser = (payload) => {
  return api.post('/Employee/auth', payload).then(({ data }) => data)
}

const createAddress = (payload) => {
  return api.post('/Address', payload).then(({ data }) => data)
}

const getAddress = () => {
  return api.get('/Address').then(({ data }) => serialize(data))
}

const getAddressForUsing = () => {
  return api.get('/Address').then(({ data }) => serialize(data))
}

const getTTN = () => {
  return api.get('/Ttn').then(({ data }) => serialize(data))
}

const createTTN = (payload) => {
  return api.post('/Ttn', payload).then(({ data }) => data)
}

const getParentsCategory = () => {
  return api.get('/Category').then(({ data }) => data)
}

const getCategory = () => {
  return api.get('/Category').then(({ data }) => serialize(data))
}

const createCategory = (payload) => {
  return api.post('/Category/create', payload).then(({ data }) => data)
}

const getProducts = () => {
  return api.get('/Product').then(({ data }) => serialize(data))
}

const createProduct = (payload) => {
  return api.post('/Product/create', payload).then(({ data }) => data)
}

const getAgentTypes = () => {
  return api.get('/AgentType').then(({ data }) => data)
}

const getAgents = () => {
  return api.get('/Agent').then(({ data }) => serialize(data))
}

const createAgent = (payload) => {
  return api.post('/Agent/create', payload).then(({ data }) => data)
}

const serialize = (payload) => {
  return payload.map((item, index) => {
    delete item.id

    for (const key in item) {
      if (!item[key]) {
        item[key] = '-'
      }
    }

    return Object.assign({ id: index + 1 }, { ...item })
  })
}

export default {
  authorizeUser,
  address: {
    createAddress,
    getAddress,
    getAddressForUsing
  },
  ttn: {
    getTTN,
    createTTN
  },
  category: {
    getCategory,
    getParentsCategory,
    createCategory
  },
  product: {
    getProducts,
    createProduct
  },
  agent: {
    getAgentTypes,
    getAgents,
    createAgent
  }
}
