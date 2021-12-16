<template>
  <div class="main">
    <component
      :is="showSidebar ? 'CloseIcon' : 'MenuIcon'"
      class="main__sidebar-btn"
      @click="showSidebar = !showSidebar"
    />

    <transition name="fade">
      <div
        @click.self="showSidebar = false"
        v-if="showSidebar"
        class="main__sidebar"
      >
        <navbar />
      </div>
    </transition>

    <div class="main__body">
      <router-view />
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Sidebar'
import { CloseIcon, MenuIcon } from '@iconicicons/vue3'

export default {
  name: 'Main',
  components: {
    Navbar,
    MenuIcon,
    CloseIcon
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

  &__sidebar {
    z-index: $sidebarZIndex;
    height: 100vh;
    top: 0;
    left: 0;
    position: fixed;
    width: 100%;
    background-color: rgba($black, .3);
  }

  &__body {
    flex-grow: 1;
    padding: $mainGapY $mainGapX;
    overflow-y: scroll;
  }
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.2s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
