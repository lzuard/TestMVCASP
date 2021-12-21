<template>
  <div class="main">
    <sidebar-burger v-model="showSidebar" class="main__sidebar-btn" />

    <navbar v-model="showSidebar" />

    <div class="main__body">
      <router-view v-slot="{ Component }">
        <transition name="scale" mode="out-in">
          <component :is="Component" />
        </transition>
      </router-view>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Sidebar'
import SidebarBurger from '@/components/Sidebar/sidebar-burger'

export default {
  name: 'Main',
  components: {
    Navbar,
    SidebarBurger
  },
  data: () => {
    return {
      showSidebar: false
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.main {
  display: flex;

  &__sidebar-btn {
    position: fixed;
    top: $sidebarButtonPos;
    left: $sidebarButtonPos;
    color: $blue;
    z-index: $sidebarZIndex + 1;
  }

  &__body {
    flex-grow: 1;
    padding: $mainGapY $mainGapX 80px;
    overflow-y: scroll;
  }
}
</style>
