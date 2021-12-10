<template>
  <div class="input-field">
    <input
      v-maska="type === 'tel' ? mask : ''"
      :class="[
        type === 'checkbox' ? 'form-check-input' : 'form-control',
        {
          'is-invalid': isError,
        }
      ]"
      :placeholder="placeholder"
      :type="type"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
      @change="emitCheckboxEvent($event.target.checked)"
    />

    <span
      v-if="isError"
      class="input-error-caption"
    >
      {{ errorText }}
    </span>
  </div>
</template>

<script>
import { maska } from 'maska'

export default {
  name: 'InputField',
  data: () => {
    return {
      mask: '+7(###)###-##-##'
    }
  },
  props: {
    type: {
      type: String,
      default: 'text',
      validation (value) {
        return ['text', 'number', 'date', 'password', 'checkbox'].includes(value)
      }
    },

    placeholder: {
      type: String,
      require: true
    },

    modelValue: {
      type: [String, Boolean],
      default: ''
    },

    isError: {
      type: Boolean,
      default: false
    },

    errorText: {
      type: String,
      default: ''
    }
  },
  emits: ['update:modelValue'],
  directives: { maska },
  methods: {
    emitCheckboxEvent (value) {
      if (this.type === 'checkbox') {
        console.log('emiting', value)
        this.$emit('update:modelValue', value)
      }
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.input-field {
  position: relative;
}
</style>
