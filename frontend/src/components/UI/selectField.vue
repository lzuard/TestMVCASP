<template>
  <div class="select-field">
    <select
      :class="[
        'form-select',
        {
          'is-invalid': isError
        }
      ]"
      :value="modelValue"
      @change="$emit('update:modelValue', +$event.target.value)"
    >
      <option selected disabled>
        {{ placeholder }}
      </option>

      <option
        v-for="(selectItem, index) in values"
        :key="index"
        :value="selectItem.value"
      >
        {{ selectItem.text }}
      </option>
    </select>

    <span
      v-if="isError"
      class="input-error-caption input-error-caption--select"
    >
      {{ errorText }}
    </span>
  </div>
</template>

<script>
export default {
  name: 'selectField',
  emits: ['update:modelValue'],
  props: {
    placeholder: {
      type: String,
      default: ''
    },
    values: {
      type: Array,
      required: true
    },
    modelValue: {
      type: Number,
      default: null
    },
    isError: {
      type: Boolean,
      default: false
    },
    errorText: {
      type: String,
      default: ''
    }
  }
}
</script>

<style>
.select-field {
  position: relative;
}
</style>
