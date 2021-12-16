import { UPDATE_AUTH_STATE } from '@/store/modules/auth/mutation-types'
import { authorizeUser } from '@/services/api'

const state = {
  isAuth: false
}

const mutations = {
  [UPDATE_AUTH_STATE] (state, isAuth) {
    state.isAuth = isAuth
  }
}

const actions = {
  authenticateUser ({ commit }, dataToAuth) {
    return authorizeUser(dataToAuth)
      .then(() => {
        commit(UPDATE_AUTH_STATE, true)
      })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
