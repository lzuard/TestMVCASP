import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import locale from './localization'

/** Styles import */
import 'bootstrap/dist/css/bootstrap.min.css'
import '@/styles/global.scss'

createApp(App)
  .use(locale)
  .use(store)
  .use(router)
  .mount('#app')
