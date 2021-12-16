<template>
  <div class="table-responsive editing-table">
    <table class="table table-bordered border-dark">
      <thead>
      <tr>
        <th
          v-for="(head, index) in tableHeaders"
          :key="index"
        >
          {{ head }}
        </th>
      </tr>
      </thead>
      <tbody>
      <tr
        v-for="(row, index) in tableData"
        :key="index"
      >
        <td
          v-for="(cell, innerIndex) in row"
          :key="innerIndex"
        >
          {{ cell }}
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'editing-table',
  props: {
    tableHeaders: {
      type: Array,
      default: () => ([])
    },
    tableData: {
      type: Array,
      default: () => ([])
    }
  }
}
</script>
