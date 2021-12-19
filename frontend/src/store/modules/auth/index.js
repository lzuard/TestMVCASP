import { authorizeUser } from '@/services/api'
import {
  UPDATE_AUTH_STATE,
  SET_USERNAME
} from './mutation-types'

const state = {
  isAuth: false,
  userName: null
}

const mutations = {
  [UPDATE_AUTH_STATE] (state, payload) {
    state.isAuth = payload.isAuth
  },

  [SET_USERNAME] (state, payload) {
    state.userName = payload.name
  }
}

const actions = {
  authenticateUser ({ commit }, dataToAuth) {
    return authorizeUser(dataToAuth)
      .then((name) => {
        commit(UPDATE_AUTH_STATE, { isAuth: true })
      })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
