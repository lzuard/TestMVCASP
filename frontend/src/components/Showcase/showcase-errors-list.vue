<template>
  <div class="col-auto">
    <layout-alert type="danger">
      <ul class="showcase-errors-list list-group">
        <li
          v-for="(error, index) in errors"
          :key="index"
        >
          <span class="fw-bolder">{{ $t(error[propertyField]) }}</span>: {{ error[messageField] }}
        </li>
      </ul>
    </layout-alert>
  </div>
</template>

<script>
import LayoutAlert from '@/components/Layouts/layout-alert'

export default {
  name: 'showcase-errors-list',
  components: {
    LayoutAlert
  },
  props: {
    errors: {
      type: Array,
      require: true
    },
    messageField: {
      type: String,
      default: '$message'
    },
    propertyField: {
      type: String,
      default: '$property'
    }
  }
}
</script>
