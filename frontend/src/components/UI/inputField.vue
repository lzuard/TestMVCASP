<template>
  <div class="input-field">
    <input
      v-maska="type === 'tel' ? mask : ''"
      :class="[
        'form-control',
        {
          'is-invalid': isError
        }
      ]"
      :placeholder="placeholder"
      :type="type"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
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
        return ['text', 'number', 'date', 'password'].includes(value)
      }
    },

    placeholder: {
      type: String,
      require: true
    },

    modelValue: {
      type: String,
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
  directives: { maska }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.input-field {
  position: relative;
}
</style>
