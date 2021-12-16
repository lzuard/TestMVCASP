<template>
  <showcase-create class="report" title="Отчеты">
    <ul class="nav nav-tabs mb-5">
      <li
        v-for="(tab, index) in tabs"
        :key="index"
        class="nav-item"
      >
        <router-link
          class="nav-link"
          active-class="active"
          :to="tab.path"
        >
          {{ tab.title }}
        </router-link>
      </li>
    </ul>

    <router-view v-slot="{ Component }">
      <transition name="scale" mode="out-in">
        <component :is="Component" />
      </transition>
    </router-view>
  </showcase-create>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'

export default {
  name: 'Report',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      tabs: [
        {
          title: 'Стоимость заказа и список его товаров',
          path: '/products-in-order'
        },
        {
          title: 'Поставщики с кол-вом поставок за период',
          path: '/suppliers-period'
        },
        {
          title: 'Список заказов клиента',
          path: '/client-orders'
        },
        {
          title: 'Популярные товары',
          path: '/popular'
        }
      ]
    }
  }
}
</script>

<style lang="scss">
.report {
  .filter__items {
    display: block;
  }

  &-head {
    display: flex;
    margin-bottom: 15px;

    .input-field {
      width: 100%;
      max-width: 320px;
    }

    & > *:not(:first-child) {
      margin-left: 15px;
    }
  }
}
</style>
