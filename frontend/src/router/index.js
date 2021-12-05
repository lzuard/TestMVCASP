import { createRouter, createWebHistory } from 'vue-router'
import Auth from '@/views/Auth/Auth'
import Main from '@/views/Main/Main'

import AgentList from '@/views/Main/Agent/AgentList'
import AgentCreate from '@/views/Main/Agent/AgentCreate'

import Report from '@/views/Main/Report/Report'

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
      },
      {
        path: '/agents/create',
        name: 'Create agent',
        component: AgentCreate,
        meta: {
          title: 'Создать контрагента'
        }
      },
      {
        path: '/reports',
        name: 'Show reports',
        component: Report,
        meta: {
          title: 'Отчеты'
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
