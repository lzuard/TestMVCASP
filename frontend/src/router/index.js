import { createRouter, createWebHistory } from 'vue-router'
import Auth from '@/views/Auth/Auth'
import Main from '@/views/Main/Main'

import AgentList from '@/views/Main/Agent/AgentList'
import AgentCreate from '@/views/Main/Agent/AgentCreate'

import Report from '@/views/Main/Report/Report'

import TTNList from '@/views/Main/TTN/TTNList'

import OrderList from '@/views/Main/Order/OrderList'

import ProductList from '@/views/Main/Product/ProductList'

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
        path: '/products',
        name: 'Show product',
        component: ProductList,
        meta: {
          title: 'Список товаров'
        }
      },
      {
        path: '/ttn/create',
        name: 'Create TTN',
        component: AgentList,
        meta: {
          title: 'Создать ТТН'
        }
      },
      {
        path: '/orders',
        name: 'Show orders',
        component: OrderList,
        meta: {
          title: 'Список заказов'
        }
      },
      {
        path: '/orders/create',
        name: 'Create orders',
        component: OrderList,
        meta: {
          title: 'Создать заказ'
        }
      },
      {
        path: '/ttn',
        name: 'Show TTN',
        component: TTNList,
        meta: {
          title: 'Список ТТН'
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
