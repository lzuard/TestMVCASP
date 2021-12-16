<template>
  <transition name="fade">
    <component
      :is="modelValue ? 'CloseIcon' : 'MenuIcon'"
      class="main__sidebar-btn"
      @click="changeBtnState($event, !modelValue)"
    />
  </transition>
</template>

<script>
import { CloseIcon, MenuIcon } from '@iconicicons/vue3'

export default {
  name: 'sidebar-burger',
  components: {
    MenuIcon,
    CloseIcon
  },
  props: {
    modelValue: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    changeBtnState (event, state = true) {
      this.$emit('update:modelValue', state)
    }
  },
  emits: ['update:modelValue']
}
</script>
