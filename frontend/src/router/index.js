import { createRouter, createWebHistory } from 'vue-router'
import Auth from '@/views/Auth/Auth'
import Main from '@/views/Main/Main'

import AgentList from '@/views/Main/Agent/AgentList'

const routes = [
  {
    path: '/auth',
    name: 'Authenticate',
    component: Auth,
    meta: {
      title: 'Войти в систему'
    }
  },
  {
    path: '/',
    name: 'Main page',
    component: Main,
    children: [
      {
        path: '/agents',
        name: 'Show agents',
        component: AgentList,
        meta: {
          title: 'Список контрагентов'
        }
      }
    ]
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
