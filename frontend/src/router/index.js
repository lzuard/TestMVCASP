import { createRouter, createWebHistory } from 'vue-router'
import Auth from '@/views/Auth/Auth'

const routes = [
  {
    path: '/auth',
    name: 'Authenticate',
    component: Auth,
    meta: {
      title: 'Войти в систему'
    }
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from, next) => {
  document.title = `${to.meta.title ?? 'Складская система'} - WareHouse Store`
  next()
})

export default router
