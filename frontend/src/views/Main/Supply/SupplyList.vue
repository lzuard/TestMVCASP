<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'
import dayjs from 'dayjs'

export default {
  name: 'SupplyList',
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
        title: 'Список поставок',
        linkToCreate: '/supplies/create',
        createCaption: 'Создать поставку',
        tableHeaders: [
          '№',
          'Поставщик',
          'Сотрудник',
          'ТК',
          'ТТН',
          'Номер платежного док.',
          'Дата поставки',
          'Принято',
          'Примечание'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.supply.getSupplies()
      .then((data) => {
        this.handlingSupplies(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке поставок')
      })
  },
  methods: {
    handlingSupplies (data) {
      data.forEach((item) => {
        item.supplier = item.supplier.organizationName
        item.employee = `${item.employee.secondName} ${item.employee.firstName}`
        item.transportCompany = item.transportCompany.organizationName
        item.ttn = item.ttn.number
        item.supplyDate = dayjs(item.supplyDate).locale('ru-ru').format('DD/MM/YYYY')
        item.isAccepted = item.isAccepted ? 'Да' : 'Нет'
      })
    }
  }
}
</script>
