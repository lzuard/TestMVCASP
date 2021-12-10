<template>
  <div class="input-field">
    <input
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
      class="input-field__error"
    >
      {{ errorText }}
    </span>
  </div>
</template>

<script>
export default {
  name: 'InputField',
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
  emits: ['update:modelValue']
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.input-field {
  position: relative;

  &__error {
    position: absolute;
    top: 50%;
    right: 30px;
    transform: translateY(-50%);
    font-size: $font-size-xs - 2px;
    font-weight: 600;
    color: $red;
    max-width: calc(100% - #{$gap-s});
    text-align: right;
    line-height: $lh-xs - 2px;
    pointer-events: none;
  }
}
</style>
