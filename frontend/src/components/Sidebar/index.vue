<template>
  <div
    class="sidebar"
  >
    <router-link tag="div" to="/auth" class="sidebar__head">
      <box-icon class="sidebar__head-icon" />
      <div>
        WareHouse<br>Store
      </div>
    </router-link>
    <div class="sidebar__content">
      <ul class="sidebar__navigation">
        <li
          v-for="(route, index) in sidebarRoutes"
          :key="index"
        >
          <router-link
            :to="route.path"
            active-class="sidebar__navigation-link--active"
            class="sidebar__navigation-link"
          >
            <component
              :is="route.icon"
              class="sidebar__navigation-icon"
            />
            {{ route.title }}
          </router-link>
        </li>
      </ul>
    </div>
    <div class="sidebar__status">
      <h5 class="sidebar__status-name">
        {{ fullName }}
      </h5>
      <log-out-icon class="sidebar__status-logout" />
    </div>
  </div>
</template>

<script>
import {
  BoxIcon,
  LogOutIcon,
  IndentRightIcon,
  ShoppingBagIcon,
  UndoIcon,
  UserIcon,
  TrashIcon,
  TruckIcon,
  FileTextIcon,
  PieChartIcon
} from '@iconicicons/vue3'

export default {
  name: 'Sidebar',
  components: {
    BoxIcon,
    LogOutIcon,
    IndentRightIcon,
    ShoppingBagIcon,
    UndoIcon,
    FileTextIcon,
    TrashIcon,
    TruckIcon,
    UserIcon,
    PieChartIcon
  },
  data: () => {
    return {
      sidebarRoutes: [
        {
          icon: 'IndentRightIcon',
          path: '/orders',
          title: 'Заказы'
        },
        {
          icon: 'ShoppingBagIcon',
          path: '/products',
          title: 'Товары'
        },
        {
          icon: 'TruckIcon',
          path: '/supplies',
          title: 'Поставки'
        },
        {
          icon: 'UndoIcon',
          path: '/returns',
          title: 'Возвраты'
        },
        {
          icon: 'TrashIcon',
          path: '/utils',
          title: 'Утилизации'
        },
        {
          icon: 'UserIcon',
          path: '/agents',
          title: 'Контрагенты'
        },
        {
          icon: 'FileTextIcon',
          path: '/ttn',
          title: 'ТТН'
        },
        {
          icon: 'PieChartIcon',
          path: '/reports',
          title: 'Отчеты'
        }
      ],
      fullName: 'Иванов И.И.'
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";
@import "~@/styles/mixins";

.sidebar {
  --offset-from-icon: 10px;

  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: stretch;
  border-right: 1px solid $darkGrey;
  background-color: $grey;
  position: relative;

  &__head {
    padding: $gap-m;
    font-size: $font-size-l;
    line-height: $lh-l;
    font-weight: 700;
    text-transform: uppercase;
    display: flex;
    text-align: left;
    align-items: center;
    border-bottom: 1px solid $darkGrey;
    cursor: pointer;

    &:hover {
      color: inherit;
      transition: none;
    }

    &-icon {
      width: 64px;
      height: 64px;
      color: $blue;
    }
  }

  &__content {
    padding: $gap-m 0;
    overflow-y: scroll;
  }

  &__navigation {
    font-weight: 600;
    font-size: $font-size-m;
    text-align: left;
    overflow-y: scroll;

    li:not(:first-child) {
      margin-top: 15px;
    }

    &-link {
      padding: 5px calc(#{$gap-m} + var(--offset-from-icon));
      display: flex;
      align-items: center;

      &--active {
        color: $white;
        @include gradientSupport;

        &:hover {
          opacity: 1;
          color: $white;
          cursor: default;
          //pointer-events: none;
        }
      }
    }

    &-icon {
      margin-right: 8px;
    }
  }

  &__status {
    border-top: 1px solid $darkGrey;
    margin-top: auto;
    padding: $gap-s $gap-s $gap-s calc(#{$gap-m} + 6px + var(--offset-from-icon));
    display: flex;
    align-items: center;

    &-name {
      font-size: $font-size-s;
      margin-right: auto;
      overflow-x: hidden;
      text-overflow: ellipsis;
      margin-bottom: 0;
      white-space: nowrap;
    }

    &-logout {
      color: $blue;
      cursor: pointer;
    }
  }
}
</style>
