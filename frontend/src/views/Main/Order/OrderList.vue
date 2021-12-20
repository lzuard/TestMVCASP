<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'
import dayjs from 'dayjs'
import { STATUSES } from '@/services/dictionaries'

export default {
  name: 'OrderList',
  components: {
    Showcase
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список заказов',
        linkToCreate: '/orders/create',
        createCaption: 'Создать заказ',
        tableHeaders: [
          'Номер заказа',
          'Клиент',
          'Сотрудник',
          'ТК',
          'Адрес',
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
        tableData: []
      }
    }
  },
  created () {
    this.$api.order.getOrders()
      .then((data) => {
        this.handlingOrders(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке заказов')
      })
  },
  methods: {
    handlingOrders (data) {
      data.forEach((item) => {
        item.client = item.client.organizationName
        item.employee = `${item.employee.secondName} ${item.employee.firstName}`
        item.transportCompany = item.transportCompany.organizationName
        item.address = `${item.address.index}, ${item.address.subject}, ${item.address.location}, ${item.address.street ?? '-'}`
        item.ttn = item.ttn.number
        item.orderingDate = dayjs(item.orderingDate).locale('ru-ru').format('DD/MM/YYYY')
        item.shipmentDate = dayjs(item.shipmentDate).locale('ru-ru').format('DD/MM/YYYY')
        item.deliveryDate = dayjs(item.deliveryDate).locale('ru-ru').format('DD/MM/YYYY')
        item.isAcceptClient = item.isAcceptClient ? 'Да' : 'Нет'
        item.isAcceptTransportCompany = item.isAcceptTransportCompany ? 'Да' : 'Нет'
        item.status = STATUSES[item.status]
      })
    }
  }
}
</script>
