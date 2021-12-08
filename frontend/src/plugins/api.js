import api from '@/services/api'

export default {
  install: (Vue) => {
    Vue.config.globalProperties.$api = api
  }
}
