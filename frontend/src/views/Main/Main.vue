<template>
  <div class="main">
    <component
      :is="mobileSidebarState ? 'CloseIcon' : 'MenuIcon'"
      class="main__sidebar-mobile-btn"
      @click="mobileSidebarState = !mobileSidebarState"
    />

    <div
      :class="[
        'main__sidebar',
        {
         'main__sidebar--mobile-open': mobileSidebarState
        }
      ]"
    >
      <navbar />
    </div>

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
      mobileSidebarState: null
    }
  },
  watch: {
    mobileSidebarState (value) {
      if (value && document.body.offsetWidth <= 768) {
        this.$cover(true)
      } else {
        this.$cover(false)
      }
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.main {
  display: flex;

  &__sidebar-mobile-btn {
    display: none;

    @media ($mediaMobile) {
      display: block;
      position: fixed;
      top: $sidebarButtonPos;
      left: $sidebarButtonPos;
      color: $blue;
      z-index: $sidebarZIndex + 1;
    }
  }

  &__sidebar {
    max-width: $sidebarWidth;
    z-index: $sidebarZIndex;
    height: 100vh;
    position: sticky;
    top: 0;
    left: 0;

    @media ($mediaMobile) {
      position: fixed;
      transform: translateX(-$sidebarWidth);
    }

    &--mobile-open {
      @media ($mediaMobile) {
        transform: translateX(0);
      }
    }
  }

  &__body {
    flex-grow: 1;
    padding: $gap-m;
    overflow-y: scroll;
  }
}
</style>
