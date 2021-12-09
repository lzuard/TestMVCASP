import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import locale from './localization'

/** Plugins */
import coverPlugin from './plugins/cover'
import apiPlugin from './plugins/api'
import Toast from 'vue-toastification'

/** Global components */
import Preloader from '@/components/UI/preloader'

/** Styles import */
import 'vue-toastification/dist/index.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import '@/styles/global.scss'

createApp(App)
  .use(locale)
  .use(store)
  .use(router)
  .use(coverPlugin)
  .use(apiPlugin)
  .use(Toast, {
    position: 'bottom-right',
    transition: 'Vue-Toastification__fade',
    pauseOnHover: false,
    hideProgressBar: true
  })
  .component('Preloader', Preloader)
  .mount('#app')
