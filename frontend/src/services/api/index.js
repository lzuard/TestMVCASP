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

const getTTN = () => {
  return api.get('/Ttn').then(({ data }) => serialize(data))
}

const createTTN = (payload) => {
  return api.post('/Ttn', payload).then(({ data }) => data)
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
    getAddress
  },
  ttn: {
    getTTN,
    createTTN
  }
}
