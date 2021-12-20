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
      .then((data) => {
        commit(UPDATE_AUTH_STATE, { isAuth: data.resultAuthentication })
        commit(SET_USERNAME, { name: data.message ?? '' })

        return data.resultAuthentication
      })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
