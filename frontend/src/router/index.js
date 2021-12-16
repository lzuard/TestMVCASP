import { createRouter, createWebHistory } from 'vue-router'
import Auth from '@/views/Auth/Auth'
import Main from '@/views/Main/Main'

import AgentList from '@/views/Main/Agent/AgentList'
import AgentCreate from '@/views/Main/Agent/AgentCreate'

import Report from '@/views/Main/Report/Report'

import TTNList from '@/views/Main/TTN/TTNList'
import TTNCreate from '@/views/Main/TTN/TTNCreate'

import OrderList from '@/views/Main/Order/OrderList'
import OrderCreate from '@/views/Main/Order/OrderCreate'

import ProductList from '@/views/Main/Product/ProductList'
import ProductCreate from '@/views/Main/Product/ProductCreate'

import SupplyList from '@/views/Main/Supply/SupplyList'
import SupplyCreate from '@/views/Main/Supply/SupplyCreate'

import ReturnList from '@/views/Main/Return/ReturnList'
import ReturnCreate from '@/views/Main/Return/ReturnCreate'

import UtilList from '@/views/Main/Util/UtilList'
import UtilCreate from '@/views/Main/Util/UtilCreate'

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
    redirect: '/orders',
    meta: {
      auth: true
    },
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
        path: '/products/create',
        name: 'Create product',
        component: ProductCreate,
        meta: {
          title: 'Создать товар'
        }
      },
      {
        path: '/supplies',
        name: 'Show supplies',
        component: SupplyList,
        meta: {
          title: 'Список поставок'
        }
      },
      {
        path: '/supplies/create',
        name: 'Create supply',
        component: SupplyCreate,
        meta: {
          title: 'Создать поставку'
        }
      },
      {
        path: '/returns',
        name: 'Show returns',
        component: ReturnList,
        meta: {
          title: 'Список возвратов'
        }
      },
      {
        path: '/returns/create',
        name: 'Create return',
        component: ReturnCreate,
        meta: {
          title: 'Создать возврат'
        }
      },
      {
        path: '/utils',
        name: 'Show utils',
        component: UtilList,
        meta: {
          title: 'Список утилизаций'
        }
      },
      {
        path: '/utils/create',
        name: 'Create util',
        component: UtilCreate,
        meta: {
          title: 'Создать утилизацию'
        }
      },
      {
        path: '/ttn/create',
        name: 'Create TTN',
        component: TTNCreate,
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
        component: OrderCreate,
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
  if (to.meta.auth) {
    next({ name: 'Authenticate' })
  }

  next()
})

router.beforeEach((to, from, next) => {
  document.title = `${to.meta.title ?? 'Складская система'} - WareHouse Store`
  next()
})

export default router
