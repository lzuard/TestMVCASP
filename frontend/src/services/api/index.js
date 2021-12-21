import api from './axiosInstance'

export const authorizeUser = (payload) => {
  return api.post('/Employee/auth', payload).then(({ data }) => data)
}

const getEmployee = () => {
  return api.get('/Employee').then(({ data }) => data)
}

const createAddress = (payload) => {
  return api.post('/Address', payload).then(({ data }) => data)
}

const getAddress = () => {
  return api.get('/Address').then(({ data }) => serialize(data))
}

const getAddressForUsing = () => {
  return api.get('/Address').then(({ data }) => data)
}

const getTTN = () => {
  return api.get('/Ttn').then(({ data }) => serialize(data))
}

const getTTNForUsing = () => {
  return api.get('/Ttn').then(({ data }) => data)
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

const getProductsForUsing = () => {
  return api.get('/Product').then(({ data }) => data)
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

const getAgentByCategory = (id) => {
  return api.post('/Agent/getByFilter', { typeId: id }).then(({ data }) => data)
}

const createAgent = (payload) => {
  return api.post('/Agent/create', payload).then(({ data }) => data)
}

const getOrders = () => {
  return api.get('/Order').then(({ data }) => serialize(data))
}

const getOrdersForUsing = () => {
  return api.get('/Order').then(({ data }) => data)
}

const createOrder = (payload) => {
  return api.post('/Order/create', payload).then(({ data }) => data)
}

const getSupplies = () => {
  return api.get('/Supply').then(({ data }) => serialize(data))
}

const createSupply = (payload) => {
  return api.post('/Supply/create', payload).then(({ data }) => data)
}

const getReturns = () => {
  return api.get('/Return').then(({ data }) => serialize(data))
}

const createReturn = (payload) => {
  return api.post('/Return/create', payload).then(({ data }) => data)
}

const getUtils = () => {
  return api.get('/Utilization').then(({ data }) => serialize(data))
}

const createUtil = (payload) => {
  return api.post('/Utilization/create', payload).then(({ data }) => data)
}

const serialize = (payload) => {
  return payload.map((item, index) => {
    delete item.id

    for (const key in item) {
      if (item[key] === null) {
        item[key] = '-'
      }
    }

    return Object.assign({ id: index + 1 }, { ...item })
  })
}

export default {
  authorizeUser,
  employee: {
    getEmployee
  },
  address: {
    createAddress,
    getAddress,
    getAddressForUsing
  },
  ttn: {
    getTTN,
    getTTNForUsing,
    createTTN
  },
  category: {
    getCategory,
    getParentsCategory,
    createCategory
  },
  product: {
    getProducts,
    getProductsForUsing,
    createProduct
  },
  agent: {
    getAgentTypes,
    getAgents,
    getAgentByCategory,
    createAgent
  },
  order: {
    getOrders,
    getOrdersForUsing,
    createOrder
  },
  supply: {
    getSupplies,
    createSupply
  },
  returns: {
    getReturns,
    createReturn
  },
  util: {
    getUtils,
    createUtil
  }
}
