<template>
  <showcase-report-cell title="Поставщики с кол-вом поставок за период">
    <div class="report-head">
      <input-field
        placeholder="Выберите начало периода"
        v-model="startDate"
      />

      <input-field
        placeholder="Выберите конец периода"
        v-model="endDate"
      />

      <layout-button class="mb-2">
        Найти
      </layout-button>
    </div>

    <editing-table :table-headers="headers" />
  </showcase-report-cell>
</template>

<script>
import ShowcaseReportCell from '@/components/Showcase/showcase-report-cell'
import EditingTable from '@/components/EditingTable'
import InputField from '@/components/UI/inputField'
import LayoutButton from '@/components/Layouts/layout-button'

export default {
  name: 'ReportClientOrders',
  components: {
    ShowcaseReportCell,
    LayoutButton,
    InputField,
    EditingTable
  },
  data: () => {
    return {
      headers: [
        '№',
        'Поставщик',
        'Кол-во поставок'
      ],
      startDate: null,
      endDate: null
    }
  }
}
</script>
