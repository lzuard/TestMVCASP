<template>
  <showcase-report-cell title="Список заказов клиента">
    <div class="report-head">
      <input-field
        placeholder="Введите номер клиента"
        v-model="searchValue"
      />

      <layout-button class="mb-2">
        Найти
      </layout-button>
    </div>

    <div>
      <span class="fw-bolder d-block">Клиент №312523</span>
      <span class="fw-bolder d-block">Общая стоимость заказов: 50 000</span>
      <editing-table :table-headers="headers" :table-data="data" />
    </div>
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
        'Номер заказа',
        'Сотрудник',
        'ТК',
        'Номер адреса',
        'ТТН',
        'Платежный документ',
        'Дата заказа',
        'Дата отгрузки',
        'Дата доставки',
        'Статус',
        'Принят ТК',
        'Принят клиентом',
        'Примечание'
      ],
      data: [
        {
          id: '7823',
          employee: 'Иванов И.И.',
          tc: 'Паровёз',
          address: '1732',
          ttn: '29873/НУ1',
          payment_doc: '597824',
          order_date: '27.06.2021',
          shipment_date: '29.06.2021',
          delivery_date: '01.07.2021',
          status: 'Завершен',
          accept_tc: 'Да',
          accept_client: 'Да',
          extra: ''
        }
      ],
      searchValue: null
    }
  }
}
</script>
