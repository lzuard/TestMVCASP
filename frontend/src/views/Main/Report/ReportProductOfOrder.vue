<template>
  <showcase-report-cell title="Стоимость заказа и список его товаров">
    <div class="report-head">
      <input-field
        placeholder="Введите номер заказа"
        v-model="searchValue"
      />

      <layout-button class="mb-2">
        Найти
      </layout-button>
    </div>

    <div>
      <span class="fw-bolder d-block">Заказ №34525</span>
      <span class="fw-bolder d-block">Общая стоимость: 50 000</span>
      <editing-table :table-headers="headers" />
    </div>
  </showcase-report-cell>
</template>

<script>
import ShowcaseReportCell from '@/components/Showcase/showcase-report-cell'
import EditingTable from '@/components/EditingTable'
import InputField from '@/components/UI/inputField'
import LayoutButton from '@/components/Layouts/layout-button'

export default {
  name: 'ReportProductOfOrder',
  components: {
    ShowcaseReportCell,
    EditingTable,
    InputField,
    LayoutButton
  },
  data: () => {
    return {
      headers: [
        'Артикул',
        'Производитель',
        'Наименование',
        'Тип',
        'Категория',
        'Кол-во',
        'Стоимость'
      ],
      searchValue: null
    }
  }
}
</script>
